namespace SataService.ApplicationContract.DTO.Auth.OTP.Verify
{
    public class VerifyOtpResponseDto
    {
        public int status {  get; set; }
        public string message { get; set; }
        public VerifyOtpData data { get; set; }
    }
}
