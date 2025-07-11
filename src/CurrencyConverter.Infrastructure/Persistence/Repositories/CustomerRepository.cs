namespace CurrencyConverter.Domain;

public class CustomerRepository : ICustomerRepository
{
    public Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        var customers = new List<Customer>
        {
            new (1, "Alice Johnson", "alice@email.com", 32, 780, DateTime.Now.AddYears(-2), "New York", "NY"),
            new (2, "Bob Smith", "bob@email.com", 45, 720, DateTime.Now.AddYears(-1), "Los Angeles", "CA"),
            new (3, "Carol Brown", "carol@email.com", 28, 650, DateTime.Now.AddMonths(-8), "Chicago", "IL"),
            new (4, "David Wilson", "david@email.com", 35, 800, DateTime.Now.AddYears(-3), "Houston", "TX"),
            new (5, "Emma Davis", "emma@email.com", 29, 690, DateTime.Now.AddMonths(-6), "Phoenix", "AZ"),
            new (6, "Frank Miller", "frank@email.com", 52, 750, DateTime.Now.AddYears(-4), "Philadelphia", "PA"),
            new (7, "Grace Taylor", "grace@email.com", 26, 680, DateTime.Now.AddMonths(-4), "San Antonio", "TX"),
            new (8, "Henry Anderson", "henry@email.com", 41, 770, DateTime.Now.AddYears(-2), "San Diego", "CA"),
            new (9, "Ivy Thomas", "ivy@email.com", 33, 710, DateTime.Now.AddMonths(-10), "Dallas", "TX"),
            new (10, "Jack Martinez", "jack@email.com", 38, 740, DateTime.Now.AddYears(-1), "San Jose", "CA")
        };

        return Task.FromResult<IEnumerable<Customer>>(customers);
    }
}   
