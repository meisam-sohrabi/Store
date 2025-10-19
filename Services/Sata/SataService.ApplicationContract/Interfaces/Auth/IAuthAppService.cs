using SataService.ApplicationContract.DTO.Auth.Captcha;
using SataService.ApplicationContract.DTO.Auth.OTP.Send;
using SataService.ApplicationContract.DTO.Auth.OTP.Verify;
using SataService.ApplicationContract.DTO.Base;

namespace SataService.ApplicationContract.Interfaces.Auth
{
    public interface IAuthAppService
    {
        Task<BaseResponseDto<SendOtpResponseDto>> SendOTP(SendOtpRequestDto otpRequestDto);
        Task<BaseResponseDto<VerifyOtpResponseDto>> VerifyOTP(VerifyOtpRequestDto otpVerifyRequestDto);
        Task<BaseResponseDto<VerifyCaptchaResponseDto>> VerifyCaptcha(VerifyCaptchaRequestDto verifyCaptchaRequestDto);

    }
}
