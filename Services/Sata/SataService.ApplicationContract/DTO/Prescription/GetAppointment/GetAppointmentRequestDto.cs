namespace SataService.ApplicationContract.DTO.Prescription.GetAppointment
{
    public class GetAppointmentRequestDto
    {
        public string nationalNumber { get; set; }
        public string mobile { get; set; }
        public string noMedicalSystem { get; set; }
        public string medicalSystemType { get; set; }
    }
}
