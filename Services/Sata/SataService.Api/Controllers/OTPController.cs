using Microsoft.AspNetCore.Mvc;
using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.DTO.OTP;
using SataService.ApplicationContract.Interfaces;

namespace SataService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        private readonly IOTPAppService _otpAppService;

        public OTPController(IOTPAppService otpAppService)
        {
            _otpAppService = otpAppService;
        }

        [HttpPost("Send-Otp")]
        public async Task<BaseResponseDto<SendOtpResponseDto>> SendOTP([FromBody] SendOtpRequestDto otpRequestDto, [FromHeader] string clientId, [FromHeader] string clinetSecret, [FromHeader] string workstationid)
        {
            return await _otpAppService.SendOTP(otpRequestDto,clientId,clinetSecret,workstationid);
        }

        [HttpPost("Verify-Otp")]
        public async Task<BaseResponseDto<VerifyOtpResponseDto>> VerifyOTP([FromBody] VerifyOtpRequestDto verifyOtpRequestDto, [FromHeader] string requestId)
        {
            return await _otpAppService.VerifyOTP(verifyOtpRequestDto,requestId);
        }
    }
}
