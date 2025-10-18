namespace SataService.ApplicationContract.DTO.Prescription.PrintPresentation.Response
{
    public class PrintPresentationResponseDto
    {
        public int status {  get; set; }
        public string message { get; set; }
        public PrintPresentationDataDto data { get; set; }
    }
}
