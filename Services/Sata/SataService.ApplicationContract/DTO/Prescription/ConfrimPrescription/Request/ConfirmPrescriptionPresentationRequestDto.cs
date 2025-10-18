namespace SataService.ApplicationContract.DTO.Prescription.ConfrimPrescription.Request
{
    public class ConfirmPrescriptionPresentationRequestDto
    {
        public string nationalNumber { get; set; }
        public string prescriptionUuid { get; set; }
        public string referringCode { get; set; }
    }
}
