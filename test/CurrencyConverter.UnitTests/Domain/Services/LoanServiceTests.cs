namespace CurrencyConverter.UnitTests;

public class LoanServiceTests : BaseDomainTests<BaseDomainTestsFixture>
{
    public LoanServiceTests(BaseDomainTestsFixture fixture) : base(fixture){}

    [Theory]
    [MemberData(nameof(LoanServiceData.CreateCurrency_GivenValidCurrencyCode_ShouldBeSuccess), MemberType = typeof(LoanServiceData))]
    public async Task CreateCurrency_GivenValidCurrencyCode_ShouldBeSuccess(string currencyCode)
    {
        var currency = await CurrencyFactory.Create(currencyCode);

        currency.ShouldNotBeNull();

        currency.Code.ShouldBe(currencyCode.ToUpperInvariant());
    }
}
