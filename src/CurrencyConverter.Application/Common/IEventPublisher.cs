namespace CurrencyConverter.Application;

public interface IEventPublisher
{
    Task PublishAsync<T>(T @event) where T : class;
}
