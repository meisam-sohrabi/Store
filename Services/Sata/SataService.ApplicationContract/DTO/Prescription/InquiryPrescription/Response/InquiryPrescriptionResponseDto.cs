namespace SataService.ApplicationContract.DTO.Prescription.InquiryPrescription.Response
{
    public class InquiryPrescriptionResponseDto
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<InquiryPrescriptionDataDto> data { get; set; }
    }
}
