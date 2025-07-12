namespace CurrencyConverter.UnitTests;

public class CustomerTests : BaseDomainTests<BaseDomainTestsFixture>
{
    public CustomerTests(BaseDomainTestsFixture fixture) : base(fixture){}

    [Theory]
    [MemberData(nameof(CustomerData.CreateCurrency_GivenValidCurrencyCode_ShouldBeSuccess), MemberType = typeof(CustomerData))]
    public async Task CreateCurrency_GivenValidCurrencyCode_ShouldBeSuccess(string currencyCode)
    {
        var currency = await CurrencyFactory.Create(currencyCode);

        currency.ShouldNotBeNull();

        currency.Code.ShouldBe(currencyCode.ToUpperInvariant());
    }

    [Theory]
    [MemberData(nameof(CustomerData.CreateCurrency_GivenEmptyCurrencyCode_ShouldThrowException), MemberType = typeof(CustomerData))]
    public async Task CreateCurrency_GivenEmptyCurrencyCode_ShouldThrowException(string currencyCode)
    {
        await Should.ThrowAsync<EmptyCodeCurrencyCreationException>(async () =>
            await CurrencyFactory.Create(currencyCode));
    }

    [Theory]
    [MemberData(nameof(CustomerData.CreateCurrency_GivenInvalidISOCurrencyCode_ShouldThrowException), MemberType = typeof(CustomerData))]
    public async Task CreateCurrency_GivenInvalidISOCurrencyCode_ShouldThrowException(string currencyCode)
    {
        await Should.ThrowAsync<InvalidISOCodeCurrencyCreationException>(async () =>
            await CurrencyFactory.Create(currencyCode));
    }
}
