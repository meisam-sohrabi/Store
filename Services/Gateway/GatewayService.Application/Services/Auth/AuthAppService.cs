using GatewayService.ApplicationContract.DTO.Auth;
using GatewayService.ApplicationContract.DTO.Base;
using GatewayService.ApplicationContract.DTO.Token;
using GatewayService.ApplicationContract.Interfaces;
using GatewayService.ApplicationContract.Interfaces.Auth;
using GatewayService.Domain.Entities;
using GatewayService.InfrastructureContract.Interfaces;
using GatewayService.InfrastructureContract.Interfaces.Command.Security;
using GatewayService.InfrastructureContract.Interfaces.Command.Session;
using GatewayService.InfrastructureContract.Interfaces.Query.Auth;
using GatewayService.InfrastructureContract.Interfaces.Query.Role;
using GatewayService.InfrastructureContract.Interfaces.Query.Security;
using GatewayService.InfrastructureContract.Interfaces.Query.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace GatewayService.Application.Services.Auth
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IAuthQueryRrepository _authQueryRrepository;
        private readonly IConfiguration _configuration;
        private readonly IRoleQueryRepository _roleQueryRepository;
        private readonly IRefreshTokenQueryRepository _refreshTokenQueryRepository;
        private readonly IRefreshTokenCommandRepository _refreshTokenCommandRepository;
        private readonly ISessionCommandRepository _sessionCommandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICookieAppService _cookieAppService;
        private readonly ISessionQueryRepository _sessionQueryRepository;
        private readonly IUserAppService _userAppService;

        public AuthAppService(IAuthQueryRrepository authQueryRrepository, IConfiguration configuration
            ,IRoleQueryRepository roleQueryRepository
            , IRefreshTokenQueryRepository refreshTokenQueryRepository,
            IRefreshTokenCommandRepository refreshTokenCommandRepository
            ,ISessionCommandRepository sessionCommandRepository
            ,IUnitOfWork unitOfWork
            ,ICookieAppService cookieAppService
            ,ISessionQueryRepository sessionQueryRepository
            ,IUserAppService userAppService)
        {
            _authQueryRrepository = authQueryRrepository;
            _configuration = configuration;
            _roleQueryRepository = roleQueryRepository;
            _refreshTokenQueryRepository = refreshTokenQueryRepository;
            _refreshTokenCommandRepository = refreshTokenCommandRepository;
            _sessionCommandRepository = sessionCommandRepository;
            _unitOfWork = unitOfWork;
            _cookieAppService = cookieAppService;
            _sessionQueryRepository = sessionQueryRepository;
            _userAppService = userAppService;
        }

        #region Login
        public async Task<BaseResponseDto<TokenDto>> Login(LoginDto loginDto)
        {
            var output = new BaseResponseDto<TokenDto>
            {
                Message = "خطا در ورود کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var currentUser = await _authQueryRrepository.GetQueryable().FirstOrDefaultAsync(c => c.UserName == loginDto.Username);
            if (currentUser == null)
            {
                output.Message = "نام کاربری یا رمز عبور اشتباه است لطفا مجددا تلاش کنید";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }
            var passCheck = await _authQueryRrepository.CheckPassword(currentUser, loginDto.Password);
            if (!passCheck)
            {
                output.Message = "نام کاربری یا رمز عبور اشتباه است لطفا مجددا تلاش کنید";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }
            var acccessToken = await GenerateAccessToken(currentUser);
            if (acccessToken == null)
            {
                output.Message = "مشکل در ایجاد توکن";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }
            var refreshToken = GenerateRefreshToken();
            var refreshTokenExit = await _refreshTokenQueryRepository.GetRefreshTokenQueryable().FirstOrDefaultAsync(r => r.UserId == currentUser.Id);
            string finalRefreshToken;
            if (refreshTokenExit == null)
            {
                var refreshTokenEntity = new RefreshTokenEntity
                {
                    Token = refreshToken,
                    UserId = currentUser.Id,
                    CreatedAt = DateTime.Now,
                    ExpiresAt = DateTime.Now.AddMinutes(5),
                };
                await _refreshTokenCommandRepository.Add(refreshTokenEntity);
                finalRefreshToken = refreshToken;
            }
            else if (refreshTokenExit.ExpiresAt < DateTime.Now)
            {
                refreshTokenExit.Token = refreshToken;
                refreshTokenExit.CreatedAt = DateTime.Now;
                refreshTokenExit.ExpiresAt = DateTime.Now.AddMinutes(5);
                _refreshTokenCommandRepository.Update(refreshTokenExit);
                finalRefreshToken = refreshToken;
            }
            else
            {
                finalRefreshToken = refreshTokenExit.Token;

            }
            var loginSession = new UserSessionEntity { UserId = currentUser.Id ,Username = currentUser.UserName };
            await _sessionCommandRepository.Add(loginSession);
            var affectedRow = await _unitOfWork.SaveChangesAsync();
            if (affectedRow > 0)
            {
                output.Message = "رفرش توکن و توکن با موفقیت درج شدند";
                output.Success = true;
                output.Data = new TokenDto { AccessToken = acccessToken, RefreshToken = finalRefreshToken };
            }
            setCookie(acccessToken, finalRefreshToken, currentUser.Id);

            output.StatusCode = output.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion


        #region Logout
        public async Task<BaseResponseDto<bool>> Logout()
        {
            var output = new BaseResponseDto<bool>
            {
                Message = "خطا در خروج کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            //var userId = _cookieService.GetCookie("UserId"); // cookie just used in category creation
            var userId = _userAppService.GetCurrentUser(); // from httpcontext
            if (userId == null)
            {
                output.Message = "خطا در دریافت ایدی یوزر";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }
            var refreshTokenExist = await _refreshTokenQueryRepository.GetRefreshTokenQueryable().FirstOrDefaultAsync(r => r.UserId == userId);
            if (refreshTokenExist == null)
            {
                output.Message = "رفرش توکن یافت نشد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }
            _refreshTokenCommandRepository.Delete(refreshTokenExist);
            var userSession = await _sessionQueryRepository.GetSessionQueryable().Where(e => e.UserId == userId && e.LogoutTime == null).OrderByDescending(e => e.LoginTime).FirstOrDefaultAsync();
            if (userSession == null)
            {
                output.Message = "عدم وجود سشن ";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }
            userSession.LogoutTime = DateTime.Now;
            _sessionCommandRepository.Update(userSession);
            await _unitOfWork.SaveChangesAsync();
            DeleteCookie("AccessToken", "RefreshToken", "UserId");

            output.Message = "کاربر با موفقیت خارج شد";
            output.Success = true;
            output.Data = true;
            output.StatusCode = output.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return output;

        }
        #endregion


        #region RefreshToken
        public async Task<BaseResponseDto<TokenDto>> RefreshTokenRequest(RefreshTokenRequestDto refreshToken)
        {
            var output = new BaseResponseDto<TokenDto>
            {
                Message = "خطا در ایجاد رفرش توکن ",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var refreshTokenExist = await _refreshTokenQueryRepository.GetRefreshTokenQueryable().FirstOrDefaultAsync(r => r.Token == refreshToken.RefreshToken);
            if (refreshTokenExist == null || refreshTokenExist.ExpiresAt < DateTime.Now)
            {
                output.Message = "رفرش توکن نا معتبر لاگ این مجدد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }
            var user = await _authQueryRrepository.GetQueryable().Where(c => c.Id == refreshTokenExist.UserId).FirstOrDefaultAsync();
            if (user == null)
            {
                output.Message = "یوزر یافت نشد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }
            var newAccessToken = await GenerateAccessToken(user);
            if (newAccessToken == null)
            {
                output.Message = "مشکل درتولید توکن";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }
            setCookie(newAccessToken, refreshTokenExist.Token, user.Id);
            output.Message = "رفرش توکن ایجاد شد";
            output.Success = true;
            output.Data = new TokenDto { AccessToken = newAccessToken, RefreshToken = refreshTokenExist.Token };
            output.StatusCode = output.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion



        #region GenerateAccessToken
        private async Task<string> GenerateAccessToken(CustomUserEntity user)
        {
            var userRole = await _roleQueryRepository.Roles(user);
            var SecreteKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingKey = new SigningCredentials(SecreteKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,user.Id),
                new(ClaimTypes.Name, user.FullName),
            };
            if (userRole != null)
            {
                foreach (var role in userRole)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }
            var jwtConfig = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(5),
            signingCredentials: signingKey

            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtConfig);
            return token;
        }
        #endregion

        #region GenereateRefreshToken
        private string GenerateRefreshToken()
        {
            var refreshToken = $"{Guid.NewGuid()}_{DateTime.Now:yyyymmddhh}";
            return refreshToken;
        }
        #endregion

        #region SetCookie
        private void setCookie(string token, string refreshToken, string userId)
        {
            _cookieAppService.SetCookie("RefreshToken", refreshToken, TimeSpan.FromMinutes(5));
            _cookieAppService.SetCookie("AccessToken", token, TimeSpan.FromMinutes(5));
            _cookieAppService.SetCookie("UserId", userId, TimeSpan.FromMinutes(5));
        }
        #endregion

        #region DeleteCookie
        private bool DeleteCookie(string accessTokenKey, string refreshTokenKey, string userIdKey)
        {
            return _cookieAppService.DeleteCookie(accessTokenKey) &&
        _cookieAppService.DeleteCookie(refreshTokenKey) &&
        _cookieAppService.DeleteCookie(userIdKey);

        }
        #endregion
    }
}
