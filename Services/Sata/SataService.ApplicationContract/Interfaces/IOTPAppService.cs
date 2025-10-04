using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.DTO.OTP;

namespace SataService.ApplicationContract.Interfaces
{
    public interface IOTPAppService
    {
        Task<BaseResponseDto<SendOtpResponseDto>> SendOTP(SendOtpRequestDto otpRequestDto, string clientId, string clinetSecret, string workstationid);
        Task<BaseResponseDto<VerifyOtpResponseDto>> VerifyOTP(VerifyOtpRequestDto otpVerifyRequestDto, string requestId);
    }
}
