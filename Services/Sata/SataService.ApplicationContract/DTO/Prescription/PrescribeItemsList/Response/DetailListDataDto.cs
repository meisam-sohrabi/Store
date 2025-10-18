namespace SataService.ApplicationContract.DTO.Prescription.PrescribeItemsList.Response
{
    public class DetailListDataDto
    {
        public string prescribeServiceUuid { get; set; }
        public string terminology { get; set; }
        public string code { get; set; }
        public string fullName { get; set; }
        public int count { get; set; }
        public int prescribeCount { get; set; }
        public string consumption { get; set; }
        public string consumptionDesc { get; set; }
        public string consumptionInstruction { get; set; }
        public string consumptionInstructionDesc { get; set; }
        public int emergency { get; set; }
        public string description { get; set; }
        public string creationDate { get; set; }
        public int bulkId { get; set; }
        public string otc { get; set; }
        public List<DetailSubListDataDto> detailList { get; set; }
    }
}
