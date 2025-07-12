namespace CurrencyConverter.UnitTests;

public class MoneyData
{
    public static IEnumerable<object[]> CreateMoney_GivenValidCurrencyAndAmount_ShouldBeSuccess =>
       new List<object[]>
       {
            new object[]
            {
                2,
                "USD"
            },
            new object[]
            {
                1,
                "eUr",
            },
       };

    public static IEnumerable<object[]> CreateMoney_GivenNegativeAmount_ShouldThrowException =>
       new List<object[]>
       {
            new object[]
            {
                -100,
                "USD"
            },
            new object[]
            {
                -90,
                "eUr",
            },
       };

    public static IEnumerable<object[]> CreateMoney_GivenEmptyCurrency_ShouldThrowException =>
       new List<object[]>
       {
            new object[]
            {
                50,
                ""
            },
            new object[]
            {
                90,
                "   ",
            },
       };

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

    public static IEnumerable<object[]> AddMoney_GivenDifferentCurrency_ShouldThrowException =>
       new List<object[]>
       {
            new object[]
            {
                8,
                "USD",
                1,
                "EUR"
            },
            new object[]
            {
                6,
                "EUR",
                2,
                "JPY"
            },
       };
}
