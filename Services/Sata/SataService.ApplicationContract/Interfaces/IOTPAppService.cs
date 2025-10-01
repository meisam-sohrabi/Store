using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.DTO.OTP;

namespace SataService.ApplicationContract.Interfaces
{
    public interface IOTPAppService
    {
        Task<BaseResponseDto<OTPResponseDto>> GetOTP(OTPRequestDto otpRequestDto);
    }
}
