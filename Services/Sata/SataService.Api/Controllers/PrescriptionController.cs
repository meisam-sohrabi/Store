using Microsoft.AspNetCore.Mvc;
using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.DTO.Prescription.DoctorsList;
using SataService.ApplicationContract.DTO.Prescription.Insurance;
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
    }
}
