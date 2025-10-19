using Microsoft.AspNetCore.Mvc;
using SataService.ApplicationContract.DTO.Auth.Captcha;
using SataService.ApplicationContract.DTO.Auth.OTP.Send;
using SataService.ApplicationContract.DTO.Auth.OTP.Verify;
using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.Interfaces.Auth;

namespace SataService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly IAuthAppService _authAppService;

        public AuthController(IAuthAppService authAppService)
        {

            _authAppService = authAppService;
        }

        [HttpPost("Send-Otp")]
        public async Task<BaseResponseDto<SendOtpResponseDto>> SendOTP([FromBody] SendOtpRequestDto otpRequestDto)
        {
            return await _authAppService.SendOTP(otpRequestDto);
        }

        [HttpPost("Verify-Otp")]
        public async Task<BaseResponseDto<VerifyOtpResponseDto>> VerifyOTP([FromBody] VerifyOtpRequestDto verifyOtpRequestDto)
        {
            return await _authAppService.VerifyOTP(verifyOtpRequestDto);
        }

        [HttpPost("Verify-Captcha")]
        public async Task<BaseResponseDto<VerifyCaptchaResponseDto>> VerifyCaptcha([FromBody] VerifyCaptchaRequestDto verifyCaptchaRequestDto)
        {
            return await _authAppService.VerifyCaptcha(verifyCaptchaRequestDto);
        }
    }
}
