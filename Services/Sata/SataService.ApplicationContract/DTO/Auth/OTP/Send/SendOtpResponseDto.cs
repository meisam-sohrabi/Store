namespace SataService.ApplicationContract.DTO.Auth.OTP.Send
{
    public class SendOtpResponseDto
    {
        public int status { get; set; }
        public string message { get; set; }
        public SendOtpDataDto data { get; set; }
    }
}
