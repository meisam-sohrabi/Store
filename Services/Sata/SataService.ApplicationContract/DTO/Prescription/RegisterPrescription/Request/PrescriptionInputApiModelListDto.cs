namespace SataService.ApplicationContract.DTO.Prescription.RegisterPrescription.Request
{
    public class PrescriptionInputApiModelListDto
    {
        public string terminology { get; set; }
        public string prescriptionTypeCode { get; set; }
        public string code { get; set; }
        public long count { get; set; }
        public int bulkId { get; set; }
        public string consumption { get; set; }
        public string consumptionInstruction { get; set; }
        public string description { get; set; }
        public bool emergency { get; set; }
        public string hospitalName { get; set; }
    }
}
