namespace CurrencyConverter.Domain;

public interface ICustomerRepository
{
    IEnumerable<Customer> FindHighCreditCustomers(decimal threshold = 750);
    IEnumerable<Customer> GetByState(string state);
    IEnumerable<Customer> GetLongTermCustomers(int yearsThreshold = 2);
    IEnumerable<Customer> GetByCreditRating(CreditRating rating);
    IEnumerable<Customer> GetPaginated(int page, int pageSize);
    Customer GetById(int id);
    IEnumerable<IGrouping<string, Customer>> GetGroupedByState();
    IEnumerable<Customer> GetSortedByCredit(bool descending = true);
}
