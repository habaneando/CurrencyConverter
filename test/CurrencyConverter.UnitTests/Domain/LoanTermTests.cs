namespace CurrencyConverter.UnitTests;

public class LoanTermTests
{
    [Theory]
    [MemberData(nameof(LoanTermData.CreateLoanTerm_ShouldBe_Success), MemberType = typeof(LoanTermData))]
    public void CreateLoanTerm_ShouldBe_Success(int months, LoanTerm result)
    {
        var loanTerm = LoanTerm.Create(months);

        loanTerm.ShouldNotBeNull();

        loanTerm.Months.ShouldBe(result.Months);
    }

    [Theory]
    [MemberData(nameof(LoanTermData.CreateLoanTerm_ShouldThrow_Exception), MemberType = typeof(LoanTermData))]
    public void CreateLoanTerm_ShouldThrow_Exception(int months)
    {
        Should.Throw<LoanTermCreationException>(() =>
            LoanTerm.Create(months)); 
    }
}
