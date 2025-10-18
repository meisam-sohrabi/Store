namespace SataService.ApplicationContract.DTO.Prescription.DoctorsList.Response
{
    public class DoctorsListResponseDto
    {
        public int status {  get; set; }
        public string message { get; set; }
        public List<DoctorListDataDto> data { get; set; }
    }
}
