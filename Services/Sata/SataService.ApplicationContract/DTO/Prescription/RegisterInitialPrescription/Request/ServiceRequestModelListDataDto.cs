namespace SataService.ApplicationContract.DTO.Prescription.RegisterInitialPrescription.Request
{
    public class ServiceRequestModelListDataDto
    {
        public string code { get; set; }
        public int count { get; set; }
        public string prescribeServiceUuid { get; set; }
        public int prescribeCount { get; set; }
        public string consumption { get; set; }
        public string consumptionInstruction { get; set; }
        public string description { get; set; }
        public int bulkId { get; set; }
        public int otc { get; set; }
        public int emergency { get; set; }
        public int type { get; set; }
        public int orderType { get; set; }
        public long deliveredDate { get; set; }
    }
}
