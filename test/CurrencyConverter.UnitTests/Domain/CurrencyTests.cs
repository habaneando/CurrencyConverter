namespace CurrencyConverter.UnitTests;

public class CurrencyTests : BaseDomainTests<BaseDomainTestsFixture>
{
    public CurrencyTests(BaseDomainTestsFixture fixture) : base(fixture){}

    [Theory]
    [MemberData(nameof(CurrencyData.CreateCurrency_GivenValidCurrencyCode_ShouldBeSuccess), MemberType = typeof(CurrencyData))]
    public async Task CreateCurrency_GivenValidCurrencyCode_ShouldBeSuccess(string currencyCode)
    {
        var currency = await CurrencyFactory.Create(currencyCode);

        currency.ShouldNotBeNull();

        currency.Code.ShouldBe(currencyCode.ToUpperInvariant());
    }

    [Theory]
    [MemberData(nameof(CurrencyData.CreateCurrency_GivenEmptyCurrencyCode_ShouldThrowException), MemberType = typeof(CurrencyData))]
    public async Task CreateCurrency_GivenEmptyCurrencyCode_ShouldThrowException(string currencyCode)
    {
        await Should.ThrowAsync<EmptyCodeCurrencyCreationException>(async () =>
            await CurrencyFactory.Create(currencyCode));
    }

    [Theory]
    [MemberData(nameof(CurrencyData.CreateCurrency_GivenInvalidISOCurrencyCode_ShouldThrowException), MemberType = typeof(CurrencyData))]
    public async Task CreateCurrency_GivenInvalidISOCurrencyCode_ShouldThrowException(string currencyCode)
    {
        await Should.ThrowAsync<InvalidISOCodeCurrencyCreationException>(async () =>
            await CurrencyFactory.Create(currencyCode));
    }
}
