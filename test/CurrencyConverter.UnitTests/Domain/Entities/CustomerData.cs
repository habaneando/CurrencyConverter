namespace CurrencyConverter.UnitTests;

public class CustomerData
{
    public static IEnumerable<object[]> CreateCurrency_GivenValidCurrencyCode_ShouldBeSuccess =>
       new List<object[]>
       {
            new object[]
            {
                "PLN"
            },
            new object[]
            {
                "THB"
            },
            new object[]
            {
                "GBP"
            }
       };

    public static IEnumerable<object[]> CreateCurrency_GivenEmptyCurrencyCode_ShouldThrowException =>
       new List<object[]>
       {
            new object[]
            {
                "    "
            },
            new object[]
            {
                ""
            }
       };

    public static IEnumerable<object[]> CreateCurrency_GivenInvalidISOCurrencyCode_ShouldThrowException =>
       new List<object[]>
       {
            new object[]
            {
                "abc"
            },
            new object[]
            {
                "TRT"
            }
       };
}
