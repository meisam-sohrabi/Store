namespace SataService.ApplicationContract.DTO.OTP
{
    public class SendOtpRequestDto
    {
        public string username { get; set; }
        public string mobile { get; set; }
        public int cid { get; set; }
    }
}
