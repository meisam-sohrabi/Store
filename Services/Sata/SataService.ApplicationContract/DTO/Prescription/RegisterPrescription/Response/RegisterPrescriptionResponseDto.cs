namespace SataService.ApplicationContract.DTO.Prescription.RegisterPrescription.Response
{
    public class RegisterPrescriptionResponseDto
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<RegisterPrescriptionResponseDataDto> data { get; set; }
    }
}
