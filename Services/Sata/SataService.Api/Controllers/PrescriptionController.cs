using Microsoft.AspNetCore.Mvc;
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
using SataService.ApplicationContract.Interfaces.Prescription;

namespace SataService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionAppService _prescriptionAppService;

        public PrescriptionController(IPrescriptionAppService prescriptionAppService)
        {
            _prescriptionAppService = prescriptionAppService;
        }

        [HttpPost("Eligible")]
        public async Task<BaseResponseDto<EligibleResponseDto>> Eligible(EligibleRequestDto eligibleRequestDto, [FromHeader] string token, [FromHeader] string sessionId, [FromHeader] string requestId)
        {
            return await _prescriptionAppService.Eligible(eligibleRequestDto, token, sessionId, requestId);
        }

        [HttpPost("DoctorsList")]
        public async Task<BaseResponseDto<DoctorsListResponseDto>> CenterDoctorList([FromHeader] string token, [FromHeader] string sessionId, [FromHeader] string requestId)
        {
            return await _prescriptionAppService.CenterDoctorList(token, sessionId, requestId);
        }


        [HttpPost("GetAppointment")]
        public async Task<BaseResponseDto<GetAppointmentResponseDto>> GetAppointment(GetAppointmentRequestDto getAppointmentRequestDto, [FromHeader] string token, [FromHeader] string sessionId, [FromHeader] string requestId)
        {
            return await _prescriptionAppService.GetAppointment(getAppointmentRequestDto, token, sessionId, requestId);
        }


        [HttpPost("ClientListTajviz")]
        public async Task<BaseResponseDto<ClientListTajvizResponseDto>> ClientListTajviz( [FromHeader] string token, [FromHeader] string sessionId, [FromHeader] string requestId)
        {
            return await _prescriptionAppService.ClientListTajviz(token, sessionId, requestId);
        }

        [HttpPost("RegisterPrescription")]
        public async Task<BaseResponseDto<RegisterPrescriptionResponseDto>> RegisterPrescription(RegisterPrescriptionRequestDto registerPrescriptionRequestDto, [FromHeader] string token, [FromHeader] string sessionId, [FromHeader] string requestId)
        {
            return await _prescriptionAppService.RegisterPrescription(registerPrescriptionRequestDto, token, sessionId, requestId);
        }

        [HttpPost("PrescribedItemsList")]
        public async Task<BaseResponseDto<PrescribeItemsListResponseDto>> PrescribedItemsList(PrescribeItemsListRequestDto prescribeItemsListRequestDto, [FromHeader] string token, [FromHeader] string sessionId, [FromHeader] string requestId)
        {
            return await _prescriptionAppService.PrescribedItemsList(prescribeItemsListRequestDto, token, sessionId, requestId);
        }

        [HttpPost("RegisterInitialPrescription")]
        public async Task<BaseResponseDto<RegisterInitialPrescriptionResponseDto>> RegisterInitialPrescription(RegisterInitialPrescriptionRequestDto registerInitialPrescriptionRequestDto, [FromHeader] string token, [FromHeader] string sessionId, [FromHeader] string requestId)
        {
            return await _prescriptionAppService.RegisterInitialPrescription(registerInitialPrescriptionRequestDto, token, sessionId, requestId);
        }


        [HttpPost("ConfirmPrescriptionPresentation")]
        public async Task<BaseResponseDto<ConfirmPrescriptionPresentationResponseDto>> ConfirmPrescriptionPresentation(ConfirmPrescriptionPresentationRequestDto confirmPrescriptionPresentationRequestDto, [FromHeader] string token, [FromHeader] string sessionId, [FromHeader] string requestId)
        {
            return await _prescriptionAppService.ConfirmPrescriptionPresentation(confirmPrescriptionPresentationRequestDto, token, sessionId, requestId);
        }

        [HttpPost("InquiryPrescription")]
        public async Task<BaseResponseDto<InquiryPrescriptionResponseDto>> InquiryPrescription(InquiryPrescriptionRequestDto inquiryPrescriptionRequestDto, [FromHeader] string token, [FromHeader] string sessionId, [FromHeader] string requestId)
        {
            return await _prescriptionAppService.InquiryPrescription(inquiryPrescriptionRequestDto, token, sessionId, requestId);
        }

        [HttpPost("PrintPresentation")]
        public async Task<BaseResponseDto<PrintPresentationResponseDto>> PrintPresentation(PrintPresentationRequestDto printPresentationRequestDto, [FromHeader] string token, [FromHeader] string sessionId, [FromHeader] string requestId)
        {
            return await _prescriptionAppService.PrintPresentation(printPresentationRequestDto, token, sessionId, requestId);
        }
    }
}
