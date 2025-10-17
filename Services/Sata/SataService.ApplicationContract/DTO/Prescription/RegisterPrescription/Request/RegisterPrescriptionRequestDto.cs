namespace SataService.ApplicationContract.DTO.Prescription.RegisterPrescription.Request
{
    public class RegisterPrescriptionRequestDto
    {
        public string nationalNumber { get; set; }
        public string nomedicalSystem { get; set; }
        public string medicalSystemType { get; set; }
        public string mobile { get; set; }
        public string trackingCode { get; set; }
        public string referringCode { get; set; }
        public string patientComplaintCode { get; set; }
        public List<PrescriptionInputApiDeleteModelListDto> prescriptionInputApiDeleteModelList { get; set; }
        public List<PrescriptionInputApiModelListDto> prescriptionInputApiModelList { get; set; }
    }
}
