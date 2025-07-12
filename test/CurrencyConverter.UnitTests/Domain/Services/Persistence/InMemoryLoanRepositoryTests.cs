namespace CurrencyConverter.UnitTests;

public class InMemoryLoanRepositoryTests : BaseDomainTests<BaseDomainTestsFixture>
{
    public InMemoryLoanRepositoryTests(BaseDomainTestsFixture fixture) : base(fixture){}

    [Theory]
    [MemberData(nameof(InMemoryLoanRepositoryData.LoanRepoGetByCustomer_GivenValidId_ShouldBeSuccess), MemberType = typeof(InMemoryLoanRepositoryData))]
    public void CustomerRepoGetByCustomer_GivenValidId_ShouldBeSuccess(int customerId, decimal amount)
    {
        var loans = LoanRepository.GetByCustomer(customerId);

        loans.ShouldNotBeNull();

        loans.ShouldNotBeEmpty();

        loans.Any(l => l.Amount == amount).ShouldBeTrue();
    }
}
