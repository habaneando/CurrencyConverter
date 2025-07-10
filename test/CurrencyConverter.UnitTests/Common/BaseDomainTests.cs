namespace CurrencyConverter.UnitTests;

public abstract class BaseDomainTests<TFixture> : IClassFixture<TFixture>
    where TFixture : BaseDomainTestsFixture, new()
{
    protected readonly TFixture Fixture;

    public ICurrencyProvider CurrencyProvider { get; init; }

    public Currency.Factory CurrencyFactory { get; init; }

    public Money.Factory MoneyFactory { get; init; }

    protected BaseDomainTests(TFixture fixture)
    {
        Fixture = fixture
            ?? throw new ArgumentNullException(nameof(fixture));

        CurrencyProvider = fixture.ServiceProvider.GetService<ICurrencyProvider>()
            ?? throw new InvalidOperationException("CurrencyProvider service is not registered.");

        CurrencyFactory = fixture.ServiceProvider.GetService<Currency.Factory>()
            ?? throw new InvalidOperationException("Currency.Factory service is not registered.");

        MoneyFactory = fixture.ServiceProvider.GetService<Money.Factory>()
            ?? throw new InvalidOperationException("Money.Factory service is not registered.");
    }
}
