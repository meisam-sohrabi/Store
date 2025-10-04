using Microsoft.AspNetCore.Mvc;
using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.DTO.Captcha;
using SataService.ApplicationContract.Interfaces;

namespace SataService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CaptchaController : ControllerBase
    {
        private readonly ICaptchaAppService _captchaAppService;

        public CaptchaController(ICaptchaAppService captchaAppService)
        {
            _captchaAppService = captchaAppService;
        }

        [HttpPost("Verify-Captcha")]
        public async Task<BaseResponseDto<VerifyCaptchaResponseDto>> VerifyCaptcha([FromBody] VerifyCaptchaRequestDto verifyCaptchaRequestDto, [FromHeader] string token)
        {
            return await _captchaAppService.VerifyCaptcha(verifyCaptchaRequestDto,token);
        }
    }
}
