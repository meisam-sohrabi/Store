//using Quartz;
//using InventoryService.ApplicationContract.Interfaces.RabbitMq;

//namespace InventoryService.Application.Services.Job
//{
//    public class JobsAppService : IJob
//    {
//        private readonly IRabbitMqAppService _rabbitMqAppService;

//        public JobsAppService(IRabbitMqAppService rabbitMqAppService)
//        {
//            _rabbitMqAppService = rabbitMqAppService;
//        }
//        public async Task Execute(IJobExecutionContext context)
//        {
            
//            await _rabbitMqAppService.PublishMessage();
//        }
//    }
//}
