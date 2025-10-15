using Microsoft.Extensions.Hosting;
using ShopService.ApplicationContract.DTO.Product;
using ShopService.ApplicationContract.Interfaces.RabbitMq;

namespace ShopService.Application.Services.Worker
{
    public class ConsumerWorker : BackgroundService
    {
        private readonly IRabbitMqAppService _rabbitMqAppService;

        public ConsumerWorker(IRabbitMqAppService rabbitMqAppService)
        {
            _rabbitMqAppService = rabbitMqAppService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _rabbitMqAppService.GetMessage<List<ProductResponseDto>>(stoppingToken);
        }
    }
}
