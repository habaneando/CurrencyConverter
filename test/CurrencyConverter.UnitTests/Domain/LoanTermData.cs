namespace CurrencyConverter.UnitTests;

public class LoanTermData
{
    public static IEnumerable<object[]> Creation_ShouldBe_Success =>
       new List<object[]>
       {
            new object[]
            {
                12,
                LoanTerm.Create(12)
            },
            new object[]
            {
                3,
                LoanTerm.Create(3)
            },
            new object[]
            {
                5,
                LoanTerm.Create(5)
            }
       };

    public static IEnumerable<object[]> Creation_ShouldThrow_Exception =>
       new List<object[]>
       {
            new object[]
            {
                -1
            },
            new object[]
            {
                2
            }

       };
}
