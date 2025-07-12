namespace CurrencyConverter.Domain;

public class LoanRepository : ILoanRepository
{
    private readonly List<Loan> _loans;

    public LoanRepository(List<Loan> loans)
    {
        _loans = loans;
    }

    public IEnumerable<Loan> FindLargeActiveLoans(decimal threshold = 50000) =>
        _loans.Where(l =>
            l.IsActive() &&
            l.IsLargeAmount(threshold));

    public IEnumerable<Loan> GetByStatus(LoanStatus status) =>
        _loans.Where(l => l.Status == status);

    public IEnumerable<Loan> GetByType(LoanType type) =>
        _loans.Where(l => l.Type == type);

    public IEnumerable<Loan> GetHighRiskLoans() =>
        _loans.Where(l => l.IsHighRisk());

    public IEnumerable<Loan> GetByCustomer(int customerId) =>
        _loans.Where(l => l.CustomerId == customerId);

    public IEnumerable<Loan> GetByRiskLevel(LoanRiskLevel riskLevel) =>
        _loans.Where(l => l.GetRiskLevel() == riskLevel);

    public IEnumerable<IGrouping<LoanStatus, Loan>> GetGroupedByStatus() =>
        _loans.GroupBy(l => l.Status);

    public IEnumerable<IGrouping<LoanType, Loan>> GetGroupedByType() =>
        _loans.GroupBy(l => l.Type);

    public object GetStatistics() =>
        new
        {
            TotalLoans = _loans.Count(),
            TotalAmount = _loans.Sum(l => l.Amount),
            AverageAmount = _loans.Average(l => l.Amount),
            MaxAmount = _loans.Max(l => l.Amount),
            MinAmount = _loans.Min(l => l.Amount)
        };
}
