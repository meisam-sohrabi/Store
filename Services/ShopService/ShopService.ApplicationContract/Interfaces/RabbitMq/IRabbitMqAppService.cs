namespace ShopService.ApplicationContract.Interfaces.RabbitMq
{
    public interface IRabbitMqAppService
    {
        Task PublishMessage<T>(T value);
        Task GetMessage<T>(CancellationToken cancellationToken = default);
    }
}
