namespace SataService.ApplicationContract.DTO.Prescription.InquiryPrescription.Request
{
    public class InquiryPrescriptionRequestDto
    {
        public string nationalNumber { get; set; }
        public string nomedicalSystem { get; set; }
        public string medicalSystemType { get; set; }
        public string mobile { get; set; }
        public string trackingCode { get; set; }
        public string referringCode { get; set; }
        public List<PrescriptionInputApiModelList> PrescriptionInputApiModelList { get; set; }
    }

}
