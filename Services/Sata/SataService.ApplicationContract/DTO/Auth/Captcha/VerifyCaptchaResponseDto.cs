namespace SataService.ApplicationContract.DTO.Auth.Captcha
{
    public class VerifyCaptchaResponseDto
    {
        public int status {  get; set; }
        public string message { get; set; }
        public VerifyCaptchaData data { get; set; }
    }
    public class VerifyCaptchaData
    {
        public bool result { get; set; }
    }
}
