namespace CurrencyConverter.UnitTests;

public class InMemoryPaymentRepositoryData
{
    public static IEnumerable<object[]> PaymentRepoGetByLoan_GivenValidId_ShouldBeSuccess =>
       new List<object[]>
       {
            new object[]
            {
                1,
                500
            }
       };
}
