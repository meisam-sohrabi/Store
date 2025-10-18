using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.DTO.Prescription.ClientListTajviz.Response;
using SataService.ApplicationContract.DTO.Prescription.ConfrimPrescription.Request;
using SataService.ApplicationContract.DTO.Prescription.ConfrimPrescription.Response;
using SataService.ApplicationContract.DTO.Prescription.DoctorsList.Response;
using SataService.ApplicationContract.DTO.Prescription.GetAppointment.Request;
using SataService.ApplicationContract.DTO.Prescription.GetAppointment.Response;
using SataService.ApplicationContract.DTO.Prescription.InquiryPrescription.Request;
using SataService.ApplicationContract.DTO.Prescription.InquiryPrescription.Response;
using SataService.ApplicationContract.DTO.Prescription.Insurance.Request;
using SataService.ApplicationContract.DTO.Prescription.Insurance.Response;
using SataService.ApplicationContract.DTO.Prescription.PrescribeItemsList.Request;
using SataService.ApplicationContract.DTO.Prescription.PrescribeItemsList.Response;
using SataService.ApplicationContract.DTO.Prescription.PrintPresentation.Request;
using SataService.ApplicationContract.DTO.Prescription.PrintPresentation.Response;
using SataService.ApplicationContract.DTO.Prescription.RegisterInitialPrescription.Request;
using SataService.ApplicationContract.DTO.Prescription.RegisterInitialPrescription.Response;
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
        Task<BaseResponseDto<PrescribeItemsListResponseDto>> PrescribedItemsList(PrescribeItemsListRequestDto prescribeItemsListRequestDto,string token, string sessionId, string requestId);
        Task<BaseResponseDto<RegisterInitialPrescriptionResponseDto>> RegisterInitialPrescription(RegisterInitialPrescriptionRequestDto registerInitialPrescriptionRequestDto, string token, string sessionId, string requestId);
        Task<BaseResponseDto<ConfirmPrescriptionPresentationResponseDto>> ConfirmPrescriptionPresentation(ConfirmPrescriptionPresentationRequestDto confirmPrescriptionPresentationRequestDto, string token, string sessionId, string requestId);
        Task<BaseResponseDto<InquiryPrescriptionResponseDto>> InquiryPrescription(InquiryPrescriptionRequestDto inquiryPrescriptionRequestDto, string token, string sessionId, string requestId);
        Task<BaseResponseDto<PrintPresentationResponseDto>> PrintPresentation(PrintPresentationRequestDto printPresentationRequestDto, string token, string sessionId, string requestId);


    }
}
