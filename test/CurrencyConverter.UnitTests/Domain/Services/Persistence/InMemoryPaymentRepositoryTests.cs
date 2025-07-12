namespace CurrencyConverter.UnitTests;

public class InMemoryPaymentRepositoryTests : BaseDomainTests<BaseDomainTestsFixture>
{
    public InMemoryPaymentRepositoryTests(BaseDomainTestsFixture fixture) : base(fixture){}

    [Theory]
    [MemberData(nameof(InMemoryPaymentRepositoryData.PaymentRepoGetByLoan_GivenValidId_ShouldBeSuccess), MemberType = typeof(InMemoryPaymentRepositoryData))]
    public void PaymentRepoGetByLoan_GivenValidId_ShouldBeSuccess(int loanId, decimal amount)
    {
        var payments = PaymentRepository.GetByLoan(loanId);

        payments.ShouldNotBeNull();

        payments.ShouldNotBeEmpty();

        payments.Any(l => l.Amount == amount).ShouldBeTrue();
    }
}
