namespace SataService.ApplicationContract.DTO.OTP
{
    public class VerifyOtpResponseDto
    {
        public int status {  get; set; }
        public string message { get; set; }
        public VerifyOtpResponseData data { get; set; }
    }
    public class VerifyOtpResponseData
    {
        public string accessToken { get; set; }
        public string expireAccessToken { get; set; }
        public string sessionId { get; set; }
        public string expireSessionId { get; set; }
    }
}
