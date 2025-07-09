namespace CurrencyConverter.Domain;

// Has ID, tracks state, owns logic tied to its own data
public class Loan
{
    public Guid Id { get; init; }

    public Money Principal { get; init; }

    public InterestRate AnnualInterestRate { get; init; }

    public LoanTerm Term { get; init; }

    public DateTime StartDate { get; init; }

    public ILoanCalculator LoanCalculator { get; init; }

    public Loan(
        Guid id,
        Money principal,
        InterestRate annualInterestRate,
        LoanTerm term,
        DateTime startDate,
        ILoanCalculator loanCalculator)
    {
        Id = id;

        Principal = principal;

        AnnualInterestRate = annualInterestRate;

        Term = term;

        StartDate = startDate;

        LoanCalculator = loanCalculator;
    }

    public Task<Money> CalculateTotalRepayment() =>
        LoanCalculator.CalculateMonthlyPayment(this);
}
