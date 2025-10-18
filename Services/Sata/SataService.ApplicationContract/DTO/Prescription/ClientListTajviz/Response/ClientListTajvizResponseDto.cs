namespace SataService.ApplicationContract.DTO.Prescription.ClientListTajviz.Response
{
    public class ClientListTajvizResponseDto
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<ClientListTajvizDataDto> data { get; set; }
    }
}
