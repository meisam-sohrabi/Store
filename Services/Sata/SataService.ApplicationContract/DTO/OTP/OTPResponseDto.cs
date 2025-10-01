namespace SataService.ApplicationContract.DTO.OTP
{
    public class OTPResponseDto
    {
        public int status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public string requestId { get; set; }
    }
}
