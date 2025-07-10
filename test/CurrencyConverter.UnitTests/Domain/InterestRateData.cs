namespace CurrencyConverter.UnitTests;

public class InterestRateData
{
    public static IEnumerable<object[]> CreateInterestRate_ShouldBe_Success =>
       new List<object[]>
       {
            new object[]
            {
                .5,
                InterestRate.Create(.5m)
            },
            new object[]
            {
                .3,
                InterestRate.Create(.3m)
            }
       };

    public static IEnumerable<object[]> CreateInterestRate_ShouldThrow_Exception =>
       new List<object[]>
       {
            new object[]
            {
                -1.5
            },
            new object[]
            {
                -2.4
            }
       };
}
