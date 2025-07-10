namespace CurrencyConverter.UnitTests;

public class MoneyTests : BaseDomainTests<BaseDomainTestsFixture>
{
    public MoneyTests(BaseDomainTestsFixture fixture)
        : base(fixture){}

    [Fact]
    public async Task AddMoney_GivenValidMoney_ShouldBeSuccess()
    {
        var money = await MoneyFactory.Create(2, "USD");

        var otherMoney = await MoneyFactory.Create(3, "USD");

        var result = await MoneyFactory.Create(5, "USD"); 

        money.Add(otherMoney).Amount.ShouldBe(result.Amount);
    }
       
}
