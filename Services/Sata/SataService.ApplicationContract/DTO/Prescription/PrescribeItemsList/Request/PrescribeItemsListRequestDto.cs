namespace SataService.ApplicationContract.DTO.Prescription.PrescribeItemsList.Request
{
    public class PrescribeItemsListRequestDto
    {
        public string nationalNumber { get; set; }
        public string trackingCode { get; set; }
        public string type { get; set; }
        public string orderType { get; set; }
    }
}
