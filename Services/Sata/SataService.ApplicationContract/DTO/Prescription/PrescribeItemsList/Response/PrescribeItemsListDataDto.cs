namespace SataService.ApplicationContract.DTO.Prescription.PrescribeItemsList.Response
{
    public class PrescribeItemsListDataDto
    {
        public string centerName { get; set; }
        public string doctorName { get; set; }
        public string trackingCode { get; set; }
        public string message { get; set; }
        public string patientComplaintCode { get; set; }
        public string patientComplaintDesc { get; set; }
        public string nationalNumber { get; set; }
        public string prescriptionDate { get; set; }
        public string nomedicalSystem { get; set; }
        public string medicalSystemType { get; set; }
        public List<DetailListDataDto> detailList {  get; set; }
    }
}
