namespace CurrencyConverter.UnitTests;

public class InMemoryLoanRepositoryData
{
    public static IEnumerable<object[]> LoanRepoGetByCustomer_GivenValidId_ShouldBeSuccess =>
       new List<object[]>
       {
            new object[]
            {
                1,
                25000m
            }
       };
}
