namespace CurrencyConverter.UnitTests;

public abstract class BaseDomainTests<TFixture> : IClassFixture<TFixture>
    where TFixture : BaseDomainTestsFixture, new()
{
    protected readonly TFixture Fixture;

    public ICurrencyRepository CurrencyRepository { get; init; }

    public Currency.Factory CurrencyFactory { get; init; }

    public Money.Factory MoneyFactory { get; init; }

    public ICustomerRepository CustomerRepository { get; init; }

    public IPaymentRepository PaymentRepository { get; init; }

    public ILoanRepository LoanRepository { get; init; }

    protected BaseDomainTests(TFixture fixture)
    {
        Fixture = fixture
            ?? throw new ArgumentNullException(nameof(fixture));

        CurrencyRepository = fixture.ServiceProvider.GetService<ICurrencyRepository>()
            ?? throw new InvalidOperationException("CurrencyProvider service is not registered.");

        CurrencyFactory = fixture.ServiceProvider.GetService<Currency.Factory>()
            ?? throw new InvalidOperationException("Currency.Factory service is not registered.");

        MoneyFactory = fixture.ServiceProvider.GetService<Money.Factory>()
            ?? throw new InvalidOperationException("Money.Factory service is not registered.");

        CustomerRepository = fixture.ServiceProvider.GetService<ICustomerRepository>()
            ?? throw new InvalidOperationException("CustomerRepository service is not registered.");

        PaymentRepository = fixture.ServiceProvider.GetService<IPaymentRepository>()
            ?? throw new InvalidOperationException("PaymentRepository service is not registered.");

        LoanRepository = fixture.ServiceProvider.GetService<ILoanRepository>()
            ?? throw new InvalidOperationException("LoanRepository service is not registered.");
    }
}
