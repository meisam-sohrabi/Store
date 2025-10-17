namespace SataService.ApplicationContract.DTO.Prescription.GetAppointment
{
    public class GetAppointmentDataDto
    {
        public string referingCode { get; set; }
        public string expertiseGrade { get; set; }
        public string academicDiscipline { get; set; }
        public string grade { get; set; }
        public string universityDegree { get; set; }
        public string doctor { get; set; }
        public string nomedicalSystem { get; set; }
        public int medicalSystemType { get; set; }
    }
}
