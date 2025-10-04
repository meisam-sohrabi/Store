using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.DTO.Captcha;

namespace SataService.ApplicationContract.Interfaces
{
    public interface ICaptchaAppService
    {
        Task<BaseResponseDto<VerifyCaptchaResponseDto>> VerifyCaptcha(VerifyCaptchaRequestDto verifyCaptchaRequestDto,string token);

    }
}
