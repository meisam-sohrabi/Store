using SataService.ApplicationContract.DTO.Prescription.GeneralMessage;

namespace SataService.ApplicationContract.DTO.Prescription.RegisterInitialPrescription.Response
{
    public class ServiceResponseModelListDataDto
    {
        public string serviceUuid { get; set; }
        public string code { get; set; }
        public int count { get; set; }
        public string message { get; set; }
        public int presentedCount { get; set; }
        public int commitmentCount { get; set; }
        public string consumption { get; set; }
        public string consumptionDesc { get; set; }
        public string consumptionInstruction { get; set; }
        public string consumptionInstructionDesc { get; set; }
        public int price { get; set; }
        public int orgAmount { get; set; }
        public int patientAmount { get; set; }
        public int totalAmount { get; set; }
        public long nextDate { get; set; }
        public int shouldSendToEsalat { get; set; }
        public int bulkId { get; set; }
        public int otc { get; set; }
        public string nameService { get; set; }
        public List<MessageDataDto> messageModelLis { get; set; } // in ke list hast yana bayad pdf o did.

    }
}
