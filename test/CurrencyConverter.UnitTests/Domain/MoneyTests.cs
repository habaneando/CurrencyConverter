namespace CurrencyConverter.UnitTests;

public class MoneyTests
{
    [Theory]
    [MemberData(nameof(MoneyData.Add_Success), MemberType = typeof(MoneyData))]
    public void Add_Success(Money money, Money otherMoney, Money result) =>
       money.Add(otherMoney).ShouldBe(result);
}
