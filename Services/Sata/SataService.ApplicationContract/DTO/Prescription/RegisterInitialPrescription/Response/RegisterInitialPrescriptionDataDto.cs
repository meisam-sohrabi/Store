namespace SataService.ApplicationContract.DTO.Prescription.RegisterInitialPrescription.Response
{
    public class RegisterInitialPrescriptionDataDto
    {
        public string message { get; set; }
        public string trackingCode { get; set; }
        public string refferingCode { get; set; }
        public string prescriptionUuid { get; set; }
        public List<ServiceResponseModelListDataDto> serviceResponseModelList { get; set; }
    }
}
