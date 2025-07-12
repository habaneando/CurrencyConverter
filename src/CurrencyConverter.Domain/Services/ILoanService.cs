namespace CurrencyConverter.Domain;

public interface ILoanService
{
    IEnumerable<object> GetCustomerLoansWithDetails();
    IEnumerable<object> GetTopCustomersByLoanAmount(int count = 3);
    bool CanApproveNewLoan(int customerId, decimal requestedAmount, LoanType loanType);
    decimal CalculateMaxLoanLimit(Customer customer);
    bool IsCustomerEligibleForRefinancing(int customerId, decimal newAmount, decimal newRate);
    object GetCustomerRiskProfile(int customerId);
}
