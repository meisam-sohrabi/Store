namespace SataService.ApplicationContract.DTO.Prescription.RegisterInitialPrescription.Request
{
    public class RegisterInitialPrescriptionRequestDto
    {
        public string nationalNumber { get; set; }
        public string trackingCode { get; set; }
        public string nomedicalSystem { get; set; }
        public string medicalSystemType { get; set; }
        public string noTechnicalManager { get; set; }
        public int noTechnicalManagerType { get; set; }
        public string mobile { get; set; }
        public List<ServiceRequestModelListDataDto> serviceRequestModelList {  get; set; }
    }
}
