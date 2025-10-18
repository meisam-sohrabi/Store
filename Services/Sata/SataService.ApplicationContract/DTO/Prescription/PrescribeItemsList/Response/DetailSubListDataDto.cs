namespace SataService.ApplicationContract.DTO.Prescription.PrescribeItemsList.Response
{
    public class DetailSubListDataDto
    {
        public string code { get; set; }
        public int count { get; set; }
        public int prescribeCount { get; set; }
        public string fullName { get; set; }
        public string consumption { get; set; }
        public string consumptionDesc { get; set; }
        public string consumptionInstruction { get; set; }
        public string consumptionInstructionDesc { get; set; }
        public string description { get; set; }
        public string centerName { get; set; }
    }
}
