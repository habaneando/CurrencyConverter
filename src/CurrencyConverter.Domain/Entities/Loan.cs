namespace CurrencyConverter.Domain;

public class Loan : Entity
{
    public int CustomerId { get; private set; }

    public decimal Amount { get; private set; }

    public decimal InterestRate { get; private set; }

    public int TermInMonths { get; private set; }

    public LoanStatus Status { get; private set; }

    public LoanType Type { get; private set; }

    public DateTime ApprovalDate { get; private set; }

    public Loan(
        int id,
        int customerId,
        decimal amount,
        decimal interestRate,
        int termInMonths,
        LoanStatus status,
        DateTime approvalDate,
        LoanType type)
    {
        Id = id;

        CustomerId = customerId;

        Amount = amount;

        InterestRate = interestRate;

        TermInMonths = termInMonths;

        Status = status;

        ApprovalDate = approvalDate;

        Type = type;
    }

    public bool IsLargeAmount(decimal threshold = 50000) =>
        Amount > threshold;

    public decimal CalculateMonthlyPayment()
    {
        if (InterestRate == 0) return Amount / TermInMonths;

        decimal monthlyRate = InterestRate / 100 / 12;

        return Amount * monthlyRate / (1 - (decimal)Math.Pow(1 + (double)monthlyRate, -TermInMonths));
    }

    public decimal CalculateTotalInterest() =>
        (CalculateMonthlyPayment() * TermInMonths) - Amount;

    public bool IsActive() =>
        Status == LoanStatus.Active;

    public bool IsHighRisk() =>
        InterestRate > 8.0m ||
        Amount > 100000 ||
        Type == LoanType.Business;

    public void Approve()
    {
        if (Status == LoanStatus.Pending)
        {
            Status = LoanStatus.Approved;

            ApprovalDate = DateTime.Now;
        }
    }

    public void Activate()
    {
        if (Status == LoanStatus.Approved)
        {
            Status = LoanStatus.Active;
        }
    }

    public void Close()
    {
        if (Status == LoanStatus.Active)
        {
            Status = LoanStatus.Closed;
        }
    }

    public void MarkAsDefault()
    {
        Status = LoanStatus.Default;
    }

    public LoanRiskLevel GetRiskLevel() =>
        (Amount, InterestRate, Type) switch
        {
            ( > 200000, > 6.0m, _) => LoanRiskLevel.High,
            ( > 100000, _, LoanType.Business) => LoanRiskLevel.High,
            ( > 50000, > 8.0m, _) => LoanRiskLevel.Medium,
            ( > 25000, _, _) => LoanRiskLevel.Medium,
            _ => LoanRiskLevel.Low
        };

    public int GetRemainingMonths()
    {
        var monthsElapsed = (DateTime.Now - ApprovalDate).Days / 30;

        return Math.Max(0, TermInMonths - monthsElapsed);
    }

    public decimal GetRemainingBalance(decimal totalPaid) =>
        Math.Max(0, Amount - totalPaid);
}
