namespace CurrencyConverter.Infrastructure;

public class InMemoryPaymentRepositorySeed
{
    public static List<Payment> Data =>
        new List<Payment>
        {
            new (1, 1, 500, DateTime.Now.AddMonths(-1), false),
            new (2, 1, 500, DateTime.Now.AddDays(-15), true),
            new (3, 2, 1800, DateTime.Now.AddMonths(-1), false),
            new (4, 2, 1800, DateTime.Now.AddDays(-10), false),
            new (5, 4, 850, DateTime.Now.AddMonths(-1), false),
            new (6, 4, 850, DateTime.Now.AddDays(-20), true),
            new (7, 5, 400, DateTime.Now.AddMonths(-2), true),
            new (8, 6, 750, DateTime.Now.AddMonths(-1), false),
            new (9, 8, 1500, DateTime.Now.AddDays(-5), false),
            new (10, 10, 780, DateTime.Now.AddMonths(-1), false),
            new (11, 10, 780, DateTime.Now.AddDays(-25), true),
            new (12, 3, 350, DateTime.Now.AddMonths(-3), false)
        };
}
