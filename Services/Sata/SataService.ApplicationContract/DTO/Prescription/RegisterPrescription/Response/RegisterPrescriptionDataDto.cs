namespace SataService.ApplicationContract.DTO.Prescription.RegisterPrescription.Response
{
    public class RegisterPrescriptionDataDto
    {
        public string nationalNumber { get; set; }
        public string medicalSystemType { get; set; }
        public string nomedicalSystem { get; set; }
        public string mobile { get; set; }
        public string trackingCode { get; set; }
        public bool reject { get; set; }
        public string referringCode { get; set; }
        public List<PrescriptionOutputApiModelListDto> prescriptionOutputApiModelList { get; set; }
    }
}
