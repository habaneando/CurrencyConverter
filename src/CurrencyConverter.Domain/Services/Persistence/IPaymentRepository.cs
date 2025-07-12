namespace CurrencyConverter.Domain;

public interface IPaymentRepository
{
    IEnumerable<Payment> FindLatePayments();
    IEnumerable<Payment> GetByLoan(int loanId);
    IEnumerable<Payment> GetRecentPayments(int daysThreshold = 30);
    IEnumerable<Payment> GetByDateRange(DateTime startDate, DateTime endDate);
    decimal GetTotalPaymentsForLoan(int loanId);
    IEnumerable<object> GetLatePaymentAnalysis();
}
