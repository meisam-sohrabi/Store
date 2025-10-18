namespace SataService.ApplicationContract.DTO.Prescription.ClientListTajviz.Response
{
    public class ClientListTajvizDataDto
    {
        public string referingCode { get; set; }
        public string nationalNumber { get; set; }
        public string fullName { get; set; }
        public byte[] memberImage { get; set; }
    }
}
