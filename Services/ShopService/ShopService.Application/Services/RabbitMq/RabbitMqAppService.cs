using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ShopService.ApplicationContract.DTO.ProductInventory;
using ShopService.ApplicationContract.Interfaces.RabbitMq;
using System.Text;
using System.Text.Json;

namespace ShopService.Application.Services.RabbitMq
{
    public class RabbitMqAppService : IRabbitMqAppService
    {
        private readonly ILogger<RabbitMqAppService> _logger;

        public RabbitMqAppService(ILogger<RabbitMqAppService> logger)
        {
            _logger = logger;
        }
        public async Task GetMessage<T>(CancellationToken cancellationToken = default)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };

                using var connection = await factory.CreateConnectionAsync();

                using var channel = await connection.CreateChannelAsync();

                await channel.ExchangeDeclareAsync(exchange: "UpdateInventory-Exchange", type: ExchangeType.Direct, durable: true, autoDelete: false, arguments: null);

                await channel.QueueDeclareAsync(queue: "UpdateInventory-Queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                await channel.QueueBindAsync(queue: "UpdateInventory-Queue", exchange: "UpdateInventory-Exchange", routingKey: "UpdateInventory-RoutingKey", arguments: null);

                var consumer = new AsyncEventingBasicConsumer(channel);

                consumer.ReceivedAsync += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var data = JsonSerializer.Deserialize<T>(message) as ProductInventoryResponseDto;
                    Console.WriteLine($"Data is updated order date is :{data.ChangeDate}");
                    await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
                };

                await channel.BasicConsumeAsync(queue: "UpdateInventory-Queue", autoAck: false, consumer: consumer);

                await Task.Delay(Timeout.Infinite, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogError("There is problem with consumer side..");
            }
           
        }





        public async Task<bool> PublishMessage<T>(T value)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };

                using var connection = await factory.CreateConnectionAsync();

                using var channel = await connection.CreateChannelAsync();

                await channel.ExchangeDeclareAsync(exchange: "PlaceOrder-Exchange", type: ExchangeType.Direct, durable: true, autoDelete: false, arguments: null);

                await channel.QueueDeclareAsync(queue: "PlaceOrder-Queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                await channel.QueueBindAsync(queue: "PlaceOrder-Queue", exchange: "PlaceOrder-Exchange", routingKey: "PlaceOrder-RoutingKey", arguments: null);

                var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value));

                var properties = new BasicProperties { Persistent = true };

                await channel.BasicPublishAsync(exchange: "PlaceOrder-Exchange", routingKey: "PlaceOrder-RoutingKey", mandatory: true, basicProperties: properties, body: messageBody);

                await channel.CloseAsync();

                await connection.CloseAsync();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError("There is problem with publishing side..");
                return false;
            }
            
        }
    }
}
