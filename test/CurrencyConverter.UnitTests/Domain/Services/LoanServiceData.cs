namespace CurrencyConverter.UnitTests;

public class LoanServiceData
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
}
