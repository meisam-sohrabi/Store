using SataService.ApplicationContract.DTO.Prescription.GeneralMessage;

namespace SataService.ApplicationContract.DTO.Prescription.InquiryPrescription.Response
{
    public class PrescriptionOutputApiModel
    {
        public string terminology { get; set; }
        public string prescriptionTypeCode { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string nameService { get; set; }
        public long count { get; set; }
        public string consumption { get; set; }
        public string consumptionDesc { get; set; }
        public string consumptionInstruction { get; set; }
        public string consumptionInstructionDesc { get; set; }
        public string creationDate { get; set; }
        public bool emergency { get; set; }
        public string hospitalName { get; set; }
        public string referringCode { get; set; }
        public int countPresented { get; set; }
        public List<MessageDataDto> messages { get; set; }
    }
}
