namespace SataService.ApplicationContract.DTO.Auth.OTP.Verify
{
    public class VerifyOtpData
    {
        public string accessToken { get; set; }
        public string expireAccessToken { get; set; }
        public string sessionId { get; set; }
        public string expireSessionId { get; set; }
    }
}
