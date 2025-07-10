namespace CurrencyConverter.UnitTests;

public class BaseDomainTestsFixture : IDisposable
{
    private bool _disposed = false;

    public IServiceProvider ServiceProvider { get; }

    public BaseDomainTestsFixture()
    {
        var services = new ServiceCollection();

        services.AddSingleton<ICurrencyProvider, InMemoryCurrencyProvider>();

        services.AddSingleton<Currency.Factory>();

        services.AddSingleton<Money.Factory>();

        ServiceProvider = services.BuildServiceProvider();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Dispose managed resources
                (ServiceProvider as IDisposable)?.Dispose();
            }

            // Free unmanaged resources if any

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
