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

        [HttpPost("OTPRequest")]
        public async Task<BaseResponseDto<OTPResponseDto>> GetOTP([FromBody] OTPRequestDto otpRequestDto)
        {
            return await _otpAppService.GetOTP(otpRequestDto);
        }
    }
}
