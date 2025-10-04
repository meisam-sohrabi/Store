namespace SataService.ApplicationContract.DTO.OTP
{
    public class SendOtpResponseDto
    {
        public int status { get; set; }
        public string message { get; set; }
        public SendOtpResponseData data { get; set; }
    }
    public class SendOtpResponseData
    {
        public string requestId { get; set; }
    }
}
