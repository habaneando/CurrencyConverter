namespace CurrencyConverter.Infrastructure;

public class InMemoryPaymentRepository : IPaymentRepository
{
    private readonly List<Payment> _payments;

    public InMemoryPaymentRepository(List<Payment> payments)
    {
        _payments = payments;
    }

    public IEnumerable<Payment> FindLatePayments() =>
        _payments.Where(p => p.IsLatePayment());

    public IEnumerable<Payment> GetByLoan(int loanId) =>
        _payments.Where(p => p.LoanId == loanId);

    public IEnumerable<Payment> GetRecentPayments(int daysThreshold = 30) =>
        _payments.Where(p => p.IsRecentPayment(daysThreshold));

    public IEnumerable<Payment> GetByDateRange(DateTime startDate, DateTime endDate) =>
        _payments.Where(p =>
            p.PaymentDate >= startDate &&
            p.PaymentDate <= endDate);

    public decimal GetTotalPaymentsForLoan(int loanId) =>
        _payments.Where(p => p.LoanId == loanId)
            .Sum(p => p.Amount);

    public IEnumerable<object> GetLatePaymentAnalysis() =>
        _payments.Where(p => p.IsLatePayment())
            .GroupBy(p => p.LoanId)
            .Select(g => new
            {
                LoanId = g.Key,
                LatePaymentCount = g.Count(),
                TotalLateAmount = g.Sum(p => p.Amount),
                TotalLateFees = g.Sum(p => p.CalculateLateFee())
            });
}
