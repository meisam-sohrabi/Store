namespace SataService.ApplicationContract.DTO.Auth.OTP.Send
{
    public class SendOtpRequestDto
    {
        public string username { get; set; }
        public string mobile { get; set; }
        public int cid { get; set; }
    }
}
