using InventoryService.ApplicationContract.DTO.ProductInventory;
using InventoryService.ApplicationContract.Interfaces.RabbitMq;
using Microsoft.Extensions.Hosting;

namespace InventoryService.Application.Services.Worker
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
            await _rabbitMqAppService.GetMessage<ProductInventoryRequestDto>(stoppingToken);
        }
    }
}
