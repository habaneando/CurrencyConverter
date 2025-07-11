namespace CurrencyConverter.Domain;

public class Payment : Entity
{
    public int LoanId { get; init; }

    public decimal Amount { get; init; }

    public DateTime PaymentDate { get; init; }

    public bool IsLate { get; init; }

    public Payment(
        int id,
        int loanId,
        decimal amount,
        DateTime paymentDate,
        bool isLate)
    {
        Id = id;
        LoanId = loanId;
        Amount = amount;
        PaymentDate = paymentDate;
        IsLate = isLate;
    }
}
