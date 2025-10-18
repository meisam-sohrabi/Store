namespace SataService.ApplicationContract.DTO.Prescription.DoctorsList.Response
{
    public class DoctorListDataDto
    {
        public int centerCode { get; set; }
        public string noMedicalSystem { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string specialty { get; set; }
        public string section { get; set; }
        public string universityDegree { get; set; }
        public string medicalSystemType { get; set; }
    }
}
