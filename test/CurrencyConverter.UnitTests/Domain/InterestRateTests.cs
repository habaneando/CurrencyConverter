namespace CurrencyConverter.UnitTests;

public class InterestRateTests
{
    [Theory]
    [MemberData(nameof(InterestRateData.CreateInterestRate_ShouldBe_Success), MemberType = typeof(InterestRateData))]
    public void CreateInterestRate_ShouldBe_Success(decimal rate, InterestRate interestRateResult)
    {
        var interestRate = InterestRate.Create(rate);

        interestRate.ShouldNotBeNull();

        interestRate.Rate.ShouldBe(interestRateResult.Rate);
    }

    [Theory]
    [MemberData(nameof(InterestRateData.CreateInterestRate_ShouldThrow_Exception), MemberType = typeof(InterestRateData))]
    public void CreateInterestRate_ShouldThrow_Exception(decimal rate)
    {
        Should.Throw<InterestRateCreationException>(() =>
            InterestRate.Create(rate)); 
    }
}
