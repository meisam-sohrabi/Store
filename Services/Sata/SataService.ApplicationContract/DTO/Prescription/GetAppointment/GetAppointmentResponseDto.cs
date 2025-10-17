namespace SataService.ApplicationContract.DTO.Prescription.GetAppointment
{
    public class GetAppointmentResponseDto
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<GetAppointmentDataDto> data { get; set; }
    }
}
