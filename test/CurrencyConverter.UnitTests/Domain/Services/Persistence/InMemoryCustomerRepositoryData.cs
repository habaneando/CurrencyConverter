namespace CurrencyConverter.UnitTests;

public class InMemoryCustomerRepositoryData
{
    public static IEnumerable<object[]> CustomerRepoGetById_GivenValidId_ShouldBeSuccess =>
       new List<object[]>
       {
            new object[]
            {
                1
            }
       };
}
