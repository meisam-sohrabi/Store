namespace SataService.ApplicationContract.DTO.Prescription.RegisterPrescription.Response
{
    public class PrescriptionOutputApiModelListDto
    {
        public string terminology { get; set; }
        public string prescriptionTypeCode { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public long count { get; set; }
        public string consumption { get; set; }
        public string consumptionDesc { get; set; }
        public string consumptionInstruction { get; set; }
        public string consumptionInstructionDesc { get; set; }
        public string creationDate { get; set; }
        public bool emergency { get; set; }
        public string hospitalName { get; set; }
        public int countPresented { get; set; }
        public string nameService { get; set; }
        public List<MessagesDataDto> messages { get; set; }
        public int bulkId { get; set; }
        public string otc { get; set; }
        public string prescribeServiceUuid { get; set; }
    }
}
