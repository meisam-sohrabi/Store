namespace SataService.ApplicationContract.DTO.Prescription.InquiryPrescription.Request
{
    public class PrescriptionInputApiModelList
    {
        public string terminology { get; set; }
        public string prescriptionTypeCode { get; set; }
        public string code { get; set; }
        public long count { get; set; }
        public string consumption { get; set; }
        public string consumptionInstruction { get; set; }
        public string description { get; set; }
        public bool emergency { get; set; }
        public string hospitalName { get; set; }
        public int countPresented { get; set; }
        public string bulkId { get; set; }
        public string otc { get; set; }
    }

}
