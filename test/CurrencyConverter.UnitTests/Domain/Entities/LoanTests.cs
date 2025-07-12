namespace CurrencyConverter.UnitTests;

public class LoanTests : BaseDomainTests<BaseDomainTestsFixture>
{
    public LoanTests(BaseDomainTestsFixture fixture) : base(fixture){}

    [Theory]
    [MemberData(nameof(LoanData.CreateCurrency_GivenValidCurrencyCode_ShouldBeSuccess), MemberType = typeof(LoanData))]
    public async Task CreateCurrency_GivenValidCurrencyCode_ShouldBeSuccess(string currencyCode)
    {
        var currency = await CurrencyFactory.Create(currencyCode);

        currency.ShouldNotBeNull();

        currency.Code.ShouldBe(currencyCode.ToUpperInvariant());
    }

    [Theory]
    [MemberData(nameof(LoanData.CreateCurrency_GivenEmptyCurrencyCode_ShouldThrowException), MemberType = typeof(LoanData))]
    public async Task CreateCurrency_GivenEmptyCurrencyCode_ShouldThrowException(string currencyCode)
    {
        await Should.ThrowAsync<EmptyCodeCurrencyCreationException>(async () =>
            await CurrencyFactory.Create(currencyCode));
    }

    [Theory]
    [MemberData(nameof(LoanData.CreateCurrency_GivenInvalidISOCurrencyCode_ShouldThrowException), MemberType = typeof(LoanData))]
    public async Task CreateCurrency_GivenInvalidISOCurrencyCode_ShouldThrowException(string currencyCode)
    {
        await Should.ThrowAsync<InvalidISOCodeCurrencyCreationException>(async () =>
            await CurrencyFactory.Create(currencyCode));
    }
}
