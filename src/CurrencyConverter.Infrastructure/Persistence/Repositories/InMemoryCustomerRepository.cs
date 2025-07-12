namespace CurrencyConverter.Infrastructure;

public class InMemoryCustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers;

    public InMemoryCustomerRepository(List<Customer> customers)
    {
        _customers = customers;
    }

    public IEnumerable<Customer> FindHighCreditCustomers(decimal threshold = 750) =>
        _customers.Where(c => c.HasHighCredit(threshold));

    public IEnumerable<Customer> GetByState(string state) =>
        _customers.Where(c => c.State == state);

    public IEnumerable<Customer> GetLongTermCustomers(int yearsThreshold = 2) =>
        _customers.Where(c => c.IsLongTermCustomer(yearsThreshold));

    public IEnumerable<Customer> GetByCreditRating(CreditRating rating) =>
        _customers.Where(c => c.GetCreditRating() == rating);

    public IEnumerable<Customer> GetPaginated(int page, int pageSize) =>
        _customers.OrderBy(c => c.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

    public Customer GetById(int id) =>
        _customers.FirstOrDefault(c => c.Id == id);

    public IEnumerable<IGrouping<string, Customer>> GetGroupedByState() =>
        _customers.GroupBy(c => c.State);

    public IEnumerable<Customer> GetSortedByCredit(bool descending = true) =>
        descending
        ? _customers.OrderByDescending(c => c.CreditScore)
        : _customers.OrderBy(c => c.CreditScore);
}   
