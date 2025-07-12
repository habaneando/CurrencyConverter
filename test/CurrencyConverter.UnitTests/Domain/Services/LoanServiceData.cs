namespace CurrencyConverter.UnitTests;

public class LoanServiceData
{
    public static IEnumerable<object[]> LoanServiceGetTopCustomersByLoanAmount_GivenValidCount_ShouldBeSuccess =>
       new List<object[]>
       {
            new object[]
            {
                5
            }
       };
}
