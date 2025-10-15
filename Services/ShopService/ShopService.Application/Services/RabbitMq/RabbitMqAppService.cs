using LogService;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ShopService.ApplicationContract.Interfaces.RabbitMq;
using System.Text;
using System.Text.Json;

namespace ShopService.Application.Services.RabbitMq
{
    public class RabbitMqAppService : IRabbitMqAppService
    {
        private readonly ILogAppService _logAppService;

        public RabbitMqAppService(ILogAppService logAppService)
        {
            _logAppService = logAppService;
        }
        public async Task GetMessage<T>(CancellationToken cancellationToken = default)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();
            await channel.ExchangeDeclareAsync(exchange: "productService", type: ExchangeType.Direct, durable: true, autoDelete: false, arguments: null);
            await channel.QueueDeclareAsync(queue: "productServiceQueue", durable: true, exclusive: false, autoDelete: false, arguments: null);
            await channel.QueueBindAsync(queue: "productServiceQueue", exchange: "productService", routingKey: "productServiceRoutingKey", arguments: null);
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var data = JsonSerializer.Deserialize<T>(message);
                await _logAppService.LogAsync(message, nameof(RabbitMqAppService), "e681b47e-4c97-4a00-93fa-11c64fb93c41");
                await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
            };
            await channel.BasicConsumeAsync(queue: "productServiceQueue", autoAck: false, consumer: consumer);
            await Task.Delay(Timeout.Infinite, cancellationToken);
        }

        public async Task PublishMessage<T>(T value)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();
            await channel.ExchangeDeclareAsync(exchange: "productService", type: ExchangeType.Direct, durable: true, autoDelete: false, arguments: null);
            await channel.QueueDeclareAsync(queue: "productServiceQueue",durable:true,exclusive:false,autoDelete:false,arguments:null);
            await channel.QueueBindAsync(queue: "productServiceQueue", exchange: "productService", routingKey: "productServiceRoutingKey", arguments: null);
            var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value));
            var properties = new BasicProperties { Persistent = true };
            await channel.BasicPublishAsync(exchange: "productService", routingKey: "productServiceRoutingKey", mandatory:true,basicProperties: properties, body: messageBody);
            await channel.CloseAsync();
            await connection.CloseAsync();
        }
    }
}
