namespace SataService.ApplicationContract.DTO.Prescription.Insurance.Response
{
    public class EligibleResponseDto
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<EligibleMemberDataDto> data { get; set; }
    }
}
