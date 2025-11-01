//using Microsoft.EntityFrameworkCore;
//using Quartz;
//using ShopService.ApplicationContract.DTO.Product;
//using ShopService.ApplicationContract.Interfaces.RabbitMq;
//using ShopService.InfrastructureContract.Interfaces.Query.Product;

//namespace ShopService.Application.Services.Job
//{
//    public class JobsAppService : IJob
//    {
//        private readonly IProductQueryRespository _productQueryRespository;
//        private readonly IRabbitMqAppService _rabbitMqAppService;

//        public JobsAppService(IProductQueryRespository productQueryRespository,IRabbitMqAppService rabbitMqAppService)
//        {
//            _productQueryRespository = productQueryRespository;
//            _rabbitMqAppService = rabbitMqAppService;
//        }
//        public async Task Execute(IJobExecutionContext context)
//        {
//            var products = await _productQueryRespository.GetQueryable().Select(c => new ProductResponseDto
//            {
//                Name = c.Name,
//                Description = c.Description,
//                Quantity = c.Quantity,
//            }).ToListAsync();
//            await _rabbitMqAppService.PublishMessage(products);
//        }
//    }
//}
