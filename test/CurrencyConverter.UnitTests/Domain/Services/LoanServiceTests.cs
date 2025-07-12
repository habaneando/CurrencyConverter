namespace CurrencyConverter.UnitTests;

public class LoanServiceTests : BaseDomainTests<BaseDomainTestsFixture>
{
    public LoanServiceTests(BaseDomainTestsFixture fixture) : base(fixture){}

    [Fact]
    public void LoanServiceGetCustomerLoansWithDetails_ShouldBeSuccess()
    {
        var customerLoans = LoanService.GetCustomerLoansWithDetails();

        customerLoans.ShouldNotBeNull();

        customerLoans.ShouldNotBeEmpty();
    }

    [Theory]
    [MemberData(nameof(LoanServiceData.LoanServiceGetTopCustomersByLoanAmount_GivenValidCount_ShouldBeSuccess), MemberType = typeof(LoanServiceData))]
    public void LoanServiceGetTopCustomersByLoanAmount_GivenValidCount_ShouldBeSuccess(int count)
    {
        var customers = LoanService.GetTopCustomersByLoanAmount(count);

        customers.ShouldNotBeNull();

        customers.ShouldNotBeEmpty();
    }
}
