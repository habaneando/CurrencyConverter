namespace CurrencyConverter.UnitTests;

public class MoneyTests : BaseDomainTests<BaseDomainTestsFixture>
{
    public MoneyTests(BaseDomainTestsFixture fixture) : base(fixture){}

    [Theory]
    [MemberData(nameof(MoneyData.AddMoney_GivenValidMoney_ShouldBeSuccess), MemberType = typeof(MoneyData))]
    public async Task AddMoney_GivenValidMoney_ShouldBeSuccess(decimal amount, string currency, decimal otherAmount, string otherCurrency, decimal expectedAmount, string expectedCurrency)
    {
        var money = await MoneyFactory.Create(amount, currency);

        var otherMoney = await MoneyFactory.Create(otherAmount, otherCurrency);

        var expectedMoney = await MoneyFactory.Create(expectedAmount, expectedCurrency);

        var result = money.Add(otherMoney);

        result.ShouldNotBeNull();

        result.ShouldBeEquivalentTo(expectedMoney);
    }
    [Theory]
    [MemberData(nameof(MoneyData.AddMoney_GivenDifferentCurrency_ShouldThrowException), MemberType = typeof(MoneyData))]
    public async Task AddMoney_GivenDifferentCurrency_ShouldThrowException(decimal amount, string currency, decimal otherAmount, string otherCurrency)
    {
        var money = await MoneyFactory.Create(amount, currency);

        var otherMoney = await MoneyFactory.Create(otherAmount, otherCurrency);

        Should.Throw<InvalidMoneyOperationException>(() =>
            money.Add(otherMoney)); 
    }
}
