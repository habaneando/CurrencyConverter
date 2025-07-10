namespace CurrencyConverter.UnitTests;

public class MoneyData
{
    public static IEnumerable<object[]> AddMoney_GivenValidMoney_ShouldBeSuccess =>
       new List<object[]>
       {
            new object[]
            {
                2,
                "USD",
                2,
                "USD",
                4,
                "USD"
            },
            new object[]
            {
                1,
                "eur",
                5,
                "eUr",
                6,
                "EuR"
            },
       };
}
