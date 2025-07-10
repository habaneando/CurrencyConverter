namespace CurrencyConverter.UnitTests;

public class LoanTermTests
{
    [Theory]
    [MemberData(nameof(LoanTermData.CreateLoanTerm_GivenValidMonths_ShouldBeSuccess), MemberType = typeof(LoanTermData))]
    public void CreateLoanTerm_GivenValidMonths_ShouldBeSuccess(int months, LoanTerm loanTermResult)
    {
        var loanTerm = LoanTerm.Create(months);

        loanTerm.ShouldNotBeNull();

        loanTerm.Months.ShouldBe(loanTermResult.Months);
    }

    [Theory]
    [MemberData(nameof(LoanTermData.CreateLoanTerm_GivenInvalidMonths_ShouldThrowException), MemberType = typeof(LoanTermData))]
    public void CreateLoanTerm_GivenInvalidMonths_ShouldThrowException(int months)
    {
        Should.Throw<LoanTermCreationException>(() =>
            LoanTerm.Create(months)); 
    }
}
