namespace SataService.ApplicationContract.DTO.Prescription.RegisterInitialPrescription.Response
{
    public class RegisterInitialPrescriptionResponseDto
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<RegisterInitialPrescriptionDataDto> data { get; set; }
    }
}
