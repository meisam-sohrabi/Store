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
        Task<BaseResponseDto<DoctorsListResponseDto>> CenterDoctorList();
        Task<BaseResponseDto<EligibleResponseDto>> Eligible(EligibleRequestDto eligibleRequestDto);
        Task<BaseResponseDto<GetAppointmentResponseDto>> GetAppointment(GetAppointmentRequestDto getAppointmentRequestDto);
        Task<BaseResponseDto<ClientListTajvizResponseDto>> ClientListTajviz ();
        Task<BaseResponseDto<RegisterPrescriptionResponseDto>> RegisterPrescription(RegisterPrescriptionRequestDto registerPrescriptionRequestDto);
        Task<BaseResponseDto<PrescribeItemsListResponseDto>> PrescribedItemsList(PrescribeItemsListRequestDto prescribeItemsListRequestDto);
        Task<BaseResponseDto<RegisterInitialPrescriptionResponseDto>> RegisterInitialPrescription(RegisterInitialPrescriptionRequestDto registerInitialPrescriptionRequestDto);
        Task<BaseResponseDto<ConfirmPrescriptionPresentationResponseDto>> ConfirmPrescriptionPresentation(ConfirmPrescriptionPresentationRequestDto confirmPrescriptionPresentationRequestDto);
        Task<BaseResponseDto<InquiryPrescriptionResponseDto>> InquiryPrescription(InquiryPrescriptionRequestDto inquiryPrescriptionRequestDto);
        Task<BaseResponseDto<PrintPresentationResponseDto>> PrintPresentation(PrintPresentationRequestDto printPresentationRequestDto);


    }
}
