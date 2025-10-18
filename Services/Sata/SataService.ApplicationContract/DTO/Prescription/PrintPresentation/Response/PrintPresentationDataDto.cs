namespace SataService.ApplicationContract.DTO.Prescription.PrintPresentation.Response
{
    public class PrintPresentationDataDto
    {
        public byte[] file { get; set; }
        public string fileName { get; set; }
        public string fileType { get; set; }
        public string fileExtension { get; set; }
        public string fileBase64 { get; set; }
    }
}
