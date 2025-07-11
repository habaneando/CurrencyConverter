namespace CurrencyConverter.Domain;

public class Loan : Entity
{
    public int CustomerId { get; init; }

    public decimal Amount { get; init; }

    public decimal InterestRate { get; init; }

    public int TermInMonths { get; init; }

    public LoanStatus Status { get; set; }

    public LoanType Type { get; set; }

    public DateTime ApprovalDate { get; init; }

    public ILoanCalculator LoanCalculator { get; init; }

    public Loan(
        int id,
        int customerId,
        decimal amount,
        decimal interestRate,
        int termInMonths,
        LoanStatus status,
        DateTime approvalDate,
        LoanType type
        //ILoanCalculator loanCalculator
        )
    {
        Id = id;

        CustomerId = customerId;

        Amount = amount;

        InterestRate = interestRate;

        TermInMonths = termInMonths;

        Status = status;

        ApprovalDate = approvalDate;

        Type = type;

        //LoanCalculator = loanCalculator;
    }

    //public Task<Money> CalculateTotalRepayment() =>
    //    LoanCalculator.CalculateMonthlyPayment(this);
}
