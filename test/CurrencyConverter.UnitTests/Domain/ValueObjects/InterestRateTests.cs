namespace CurrencyConverter.UnitTests;

public class InterestRateTests
{
    [Theory]
    [MemberData(nameof(InterestRateData.CreateInterestRate_GivenValidRate_ShouldBeSuccess), MemberType = typeof(InterestRateData))]
    public void CreateInterestRate_GivenValidRate_ShouldBeSuccess(decimal rate, InterestRate interestRateResult)
    {
        var interestRate = InterestRate.Create(rate);

        interestRate.ShouldNotBeNull();

        interestRate.Rate.ShouldBe(interestRateResult.Rate);
    }

    [Theory]
    [MemberData(nameof(InterestRateData.CreateInterestRate_GivenInvalidRate_ShouldThrowException), MemberType = typeof(InterestRateData))]
    public void CreateInterestRate_GivenInvalidRate_ShouldThrowException(decimal rate)
    {
        Should.Throw<InterestRateCreationException>(() =>
            InterestRate.Create(rate)); 
    }
}
