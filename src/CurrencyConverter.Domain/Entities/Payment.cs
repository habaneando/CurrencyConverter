namespace CurrencyConverter.Domain;

public class Payment : Entity
{
    public int LoanId { get; private set; }

    public decimal Amount { get; private set; }

    public DateTime PaymentDate { get; private set; }

    public bool IsLate { get; private set; }

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

    public bool IsLatePayment() =>
        IsLate;

    public decimal CalculateLateFee(decimal lateFeePercentage = 0.05m) =>
        IsLate ? Amount * lateFeePercentage : 0;

    public bool IsValidAmount() =>
        Amount > 0 && Amount <= 10000;

    public void MarkAsLate() =>
        IsLate = true;

    public int GetDaysLate(DateTime dueDate) =>
        IsLate
        ? Math.Max(0, (PaymentDate - dueDate).Days)
        : 0;

    public bool IsRecentPayment(int daysThreshold = 30) =>
        (DateTime.Now - PaymentDate).TotalDays <= daysThreshold;

    public PaymentStatus GetPaymentStatus(DateTime dueDate)
    {
        if (PaymentDate <= dueDate)
            return PaymentStatus.OnTime;

        var daysLate = (PaymentDate - dueDate).Days;

        return daysLate switch
        {
            <= 10 => PaymentStatus.SlightlyLate,
            <= 30 => PaymentStatus.Late,
            _ => PaymentStatus.VeryLate
        };
    }
}
