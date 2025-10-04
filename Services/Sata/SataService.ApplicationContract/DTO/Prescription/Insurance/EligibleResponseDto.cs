namespace SataService.ApplicationContract.DTO.Prescription.Insurance
{
    public class EligibleResponseDto
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<EligibleMemmberDataDto> data { get; set; }
    }
}
