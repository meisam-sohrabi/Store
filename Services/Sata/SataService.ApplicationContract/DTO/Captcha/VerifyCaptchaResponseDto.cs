namespace SataService.ApplicationContract.DTO.Captcha
{
    public class VerifyCaptchaResponseDto
    {
        public int status {  get; set; }
        public string message { get; set; }
        public VerifyCaptchaResponseData data { get; set; }
    }
    public class VerifyCaptchaResponseData
    {
        public bool result { get; set; }
    }
}
