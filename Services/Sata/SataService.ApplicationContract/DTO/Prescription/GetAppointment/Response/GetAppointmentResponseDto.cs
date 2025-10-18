namespace SataService.ApplicationContract.DTO.Prescription.GetAppointment.Response
{
    public class GetAppointmentResponseDto
    {
        public int status { get; set; }
        public string message { get; set; }
        public GetAppointmentDataDto data { get; set; }
    }
}
