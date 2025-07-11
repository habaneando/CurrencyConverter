namespace CurrencyConverter.Domain;

public interface ILoanRepository
{
    Task<IEnumerable<Loan>> GetAllLoansAsync();
}
