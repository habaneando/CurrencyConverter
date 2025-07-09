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

        Principal = principal ?? throw new ArgumentNullException(nameof(principal));

        AnnualInterestRate = annualInterestRate ?? throw new ArgumentNullException(nameof(annualInterestRate));

        Term = term ?? throw new ArgumentNullException(nameof(term));

        StartDate = startDate;

        LoanCalculator = loanCalculator;
    }

    public Money CalculateTotalRepayment()
    {
        return LoanCalculator.CalculateMonthlyPayment(this);
    }
}
