namespace SataService.ApplicationContract.DTO.Prescription.PrescribeItemsList.Response
{
    public class PrescribeItemsListResponseDto
    {
        public int status { get; set; }
        public string message { get; set; }
        public PrescribeItemsListDataDto data { get; set; }
    }
}
