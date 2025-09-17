using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopService.ApplicationContract.DTO.Account;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Security;
using ShopService.ApplicationContract.Interfaces;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces.Command.Account;
using ShopService.InfrastructureContract.Interfaces.Command.Auth;
using ShopService.InfrastructureContract.Interfaces.Command.Security;
using ShopService.InfrastructureContract.Interfaces.Command.Session;
using ShopService.InfrastructureContract.Interfaces.Query.Account;
using ShopService.InfrastructureContract.Interfaces.Query.Auth;
using ShopService.InfrastructureContract.Interfaces.Query.Security;
using ShopService.InfrastructureContract.Interfaces.Query.Session;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ShopService.Application.Services.Auth
{
    public class AuthAppService
    {
        private readonly IAccountQueryRepository _accountQueryRepository;
        private readonly IConfiguration _configuration;
        private readonly IRefreshTokenQueryRepository _refreshTokenQueryRepository;
        private readonly ICookieService _cookieService;
        private readonly IAuthCommandRepository _authCommandRepository;
        private readonly IMapper _mapper;
        private readonly IAccountCommandRepository _accountCommandRepository;
        private readonly IAuthQueryRepository _authQueryRepository;
        private readonly IRefreshTokenCommandRepository _refreshTokenCommandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISessionCommandRepository _sessionCommandRepository;
        private readonly ISessionQueryRepository _sessionQueryRepository;

        public AuthAppService(IAccountQueryRepository accountQueryRepository, IConfiguration configuration, IRefreshTokenQueryRepository refreshTokenQueryRepository
            , ICookieService cookieService, IAuthCommandRepository authCommandRepository, IMapper mapper, IAccountCommandRepository accountCommandRepository
            , IAuthQueryRepository authQueryRepository, IRefreshTokenCommandRepository refreshTokenCommandRepository, IUnitOfWork unitOfWork
            , ISessionCommandRepository sessionCommandRepository, ISessionQueryRepository sessionQueryRepository)
        {
            _accountQueryRepository = accountQueryRepository;
            _configuration = configuration;
            _refreshTokenQueryRepository = refreshTokenQueryRepository;
            _cookieService = cookieService;
            _authCommandRepository = authCommandRepository;
            _mapper = mapper;
            _accountCommandRepository = accountCommandRepository;
            _authQueryRepository = authQueryRepository;
            _refreshTokenCommandRepository = refreshTokenCommandRepository;
            _unitOfWork = unitOfWork;
            _sessionCommandRepository = sessionCommandRepository;
            _sessionQueryRepository = sessionQueryRepository;
        }

        #region Register
        public async Task<BaseResponseDto<ShowUserInfoDto>> Register(CreateUserDto createUserDto)
        {
            var output = new BaseResponseDto<ShowUserInfoDto>
            {
                Message = "خطا در درج کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var identityUser = new CustomUserEntity
            {
                FullName = createUserDto.FullName,
                Email = createUserDto.Email,
                UserName = createUserDto.Email,
                PhoneNumber = createUserDto.PhoneNumber
            };
            var result = await _authCommandRepository.Register(identityUser, createUserDto.Password);
            if (result.Succeeded)
            {
                var role = "admin";
                var roleExist = await _accountQueryRepository.RoleExist(role);
                if (!roleExist)
                {
                    var identityRole = new IdentityRole
                    {
                        Name = role
                    };

                    await _accountCommandRepository.AddRole(identityRole);
                }
                await _accountCommandRepository.AddRoleToUser(identityUser, role);

                output.Message = "کاربر با موفقبت ایجاد شد";
                output.Success = true;
                output.Data = _mapper.Map<ShowUserInfoDto>(identityUser);
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region Login
        public async Task<BaseResponseDto<TokenDto>> Login(LoginDto loginDto)
        {
            var output = new BaseResponseDto<TokenDto>
            {
                Message = "خطا در ورود کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var currentUser = await _accountQueryRepository.GetUserByUsername(loginDto.Username);
            if (currentUser == null)
            {
                output.Message = "نام کاربری یا رمز عبور اشتباه است لطفا مجددا تلاش کنید";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }
            var passCheck = await _authQueryRepository.CheckPassword(currentUser, loginDto.Password);
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
            var refreshTokenExit = await _refreshTokenQueryRepository.GetRefreshTokenQueryable().FirstOrDefaultAsync(r=> r.UserId == currentUser.Id);
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

            var loginSession = new UserSessionEntity { UserId = currentUser.Id };
            await _sessionCommandRepository.Add(loginSession);
            var affectedRow = await _unitOfWork.SaveChangesAsync();
            if (affectedRow > 0)
            {
                output.Message = "رفرش توکن و توکن با موفقیت درج شدند";
                output.Success = true;
                output.Data = new TokenDto { AccessToken = acccessToken, RefreshToken = finalRefreshToken };
            }

            setCookie(acccessToken, finalRefreshToken, currentUser.Id);

            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
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
            var userId = _cookieService.GetCookie("UserId");
            if(userId == null)
            {
                output.Message = "خطا در دریافت ایدی یوزر";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }
            var refreshTokenExist = await _refreshTokenQueryRepository.GetRefreshTokenQueryable().FirstOrDefaultAsync(r=> r.UserId == userId);
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

            output.Message = "کاربر با موفقیت لاگ اوت کرد";
            output.StatusCode = HttpStatusCode.OK;
            output.Success = true;
            output.Data = true;
            return output;

        }
        #endregion


        #region RefreshTokenRequest
        public async Task<BaseResponseDto<TokenDto>> RefreshTokenRequest(RefreshTokenRequestDto refreshToken)
        {
            var output = new BaseResponseDto<TokenDto>
            {
                Message = "خطا در ایجاد رفرش توکن ",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var refreshTokenExist = await _refreshTokenQueryRepository.GetRefreshTokenQueryable().FirstOrDefaultAsync(r=> r.Token == refreshToken.RefreshToken);
            if (refreshTokenExist == null || refreshTokenExist.ExpiresAt < DateTime.Now)
            {
                output.Message = "رفرش توکن نا معتبر";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }
            var user = await _accountQueryRepository.GetUserById(refreshTokenExist.UserId);
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



        #region GenerateRefreshToken
        private string GenerateRefreshToken()
        {
            var refreshToken = $"{Guid.NewGuid()}_{DateTime.Now:yyyymmddhh}";
            return refreshToken;
        }
        #endregion

        #region GenerateAccessToken
        private async Task<string> GenerateAccessToken(CustomUserEntity user)
        {
            var userRole = await _accountQueryRepository.Roles(user);
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
            expires: DateTime.UtcNow.AddMinutes(2),
            signingCredentials: signingKey

            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtConfig);
            return token;
        }
        #endregion

        #region SetCookie
        private void setCookie(string token, string refreshToken, string userId)
        {
            _cookieService.SetCookie("RefreshToken", refreshToken, TimeSpan.FromMinutes(5));
            _cookieService.SetCookie("AccessToken", token, TimeSpan.FromMinutes(5));
            _cookieService.SetCookie("UserId", userId, TimeSpan.FromMinutes(5));
        }
        #endregion

        #region DeleteCookie
        private bool DeleteCookie(string accessTokenKey, string refreshTokenKey, string userIdKey)
        {
            return _cookieService.DeleteCookie(accessTokenKey) &&
        _cookieService.DeleteCookie(refreshTokenKey) &&
        _cookieService.DeleteCookie(userIdKey);

        }
        #endregion


    }


}
