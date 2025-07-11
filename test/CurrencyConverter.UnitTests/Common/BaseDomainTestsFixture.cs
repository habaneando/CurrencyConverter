﻿namespace CurrencyConverter.UnitTests;

public class BaseDomainTestsFixture : IDisposable
{
    private bool _disposed = false;

    public IServiceProvider ServiceProvider { get; }

    public BaseDomainTestsFixture()
    {
        var services = new ServiceCollection();

        services.AddSingleton<ICurrencyRepository, InMemoryCurrencyRepository>();

        services.AddSingleton<Currency.Factory>();

        services.AddSingleton<Money.Factory>();

        services.AddScoped<ILoanRepository>(sp =>
            new InMemoryLoanRepository(InMemoryLoanRepositorySeed.Data));

        services.AddScoped<IPaymentRepository>( sp =>
            new InMemoryPaymentRepository(InMemoryPaymentRepositorySeed.Data));

        services.AddScoped<ICustomerRepository>(sp =>
            new InMemoryCustomerRepository(InMemoryCustomerRepositorySeed.Data));

        services.AddScoped<ILoanService, LoanService>();

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
