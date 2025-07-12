namespace CurrencyConverter.Domain;

public interface ILoanRepository
{
    IEnumerable<Loan> FindLargeActiveLoans(decimal threshold = 50000);
    IEnumerable<Loan> GetByStatus(LoanStatus status);
    IEnumerable<Loan> GetByType(LoanType type);
    IEnumerable<Loan> GetHighRiskLoans();
    IEnumerable<Loan> GetByCustomer(int customerId);
    IEnumerable<Loan> GetByRiskLevel(LoanRiskLevel riskLevel);
    IEnumerable<IGrouping<LoanStatus, Loan>> GetGroupedByStatus();
    IEnumerable<IGrouping<LoanType, Loan>> GetGroupedByType();
    object GetStatistics();
}
