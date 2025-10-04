namespace SataService.ApplicationContract.DTO.Prescription.Insurance
{
    public class EligibleMemmberDataDto
    {
        public string nationalNumber { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string birthDate { get; set; }
        public int gender { get; set; }
        public string relationType { get; set; }
        public int relationTypeCode { get; set; }
        public string mobile { get; set; }
        public int isCovered { get; set; }
        public string isCoveredTitle { get; set; }
        public int esarStatusType { get; set; }
        public string esarStatusTitle { get; set; }
        public long insuranceNumber { get; set; }
        public int issuerType { get; set; }
        public string age { get; set; }
        public string address { get; set; }
        public int insurer { get; set; }
        public List<EligibleDiseaseDataDto> diseases { get; set; }
        public string nationalNumberSarparast { get; set; }
        public string nameFamilySarparast { get; set; }
        public string militaryStatusType { get; set; }
        public string militaryStatus { get; set; }
        public string memberImage { get; set; }
    }
}
