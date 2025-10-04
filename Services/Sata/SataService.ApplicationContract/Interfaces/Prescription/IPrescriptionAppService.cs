using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.DTO.Prescription.DoctorsList;
using SataService.ApplicationContract.DTO.Prescription.Insurance;

namespace SataService.ApplicationContract.Interfaces.Prescription
{
    public interface IPrescriptionAppService
    {
        Task<BaseResponseDto<DoctorsListResponseDto>> CenterDoctorList(string token, string sessionId, string requestId);
        Task<BaseResponseDto<EligibleResponseDto>> Eligible(EligibleRequestDto eligibleRequestDto, string token, string sessionId, string requestId);
    }
}
