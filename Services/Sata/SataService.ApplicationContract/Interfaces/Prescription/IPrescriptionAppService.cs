using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.DTO.Prescription.ClientListTajviz;
using SataService.ApplicationContract.DTO.Prescription.DoctorsList;
using SataService.ApplicationContract.DTO.Prescription.GetAppointment;
using SataService.ApplicationContract.DTO.Prescription.Insurance;
using SataService.ApplicationContract.DTO.Prescription.RegisterPrescription.Request;
using SataService.ApplicationContract.DTO.Prescription.RegisterPrescription.Response;

namespace SataService.ApplicationContract.Interfaces.Prescription
{
    public interface IPrescriptionAppService
    {
        Task<BaseResponseDto<DoctorsListResponseDto>> CenterDoctorList(string token, string sessionId, string requestId);
        Task<BaseResponseDto<EligibleResponseDto>> Eligible(EligibleRequestDto eligibleRequestDto, string token, string sessionId, string requestId);
        Task<BaseResponseDto<GetAppointmentResponseDto>> GetAppointment(GetAppointmentRequestDto getAppointmentRequestDto, string token, string sessionId, string requestId);
        Task<BaseResponseDto<ClientListTajvizResponseDto>> ClientListTajviz (string token, string sessionId, string requestId);
        Task<BaseResponseDto<RegisterPrescriptionResponseDto>> RegisterPrescription(RegisterPrescriptionRequestDto registerPrescriptionRequestDto, string token, string sessionId, string requestId);
    }
}
