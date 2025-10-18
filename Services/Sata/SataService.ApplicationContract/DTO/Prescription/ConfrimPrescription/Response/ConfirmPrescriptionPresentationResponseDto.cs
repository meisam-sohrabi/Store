namespace SataService.ApplicationContract.DTO.Prescription.ConfrimPrescription.Response
{
    public class ConfirmPrescriptionPresentationResponseDto
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<ConfirmPrescriptionDataDto> data { get; set; }
    }
}
