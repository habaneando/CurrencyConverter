namespace CurrencyConverter.Infrastructure;

public class InMemoryLoanRepositorySeed
{
    public static List<Loan> Data =>
        new List<Loan>
        {
            new (1, 1, 25000, 5.5m, 60, LoanStatus.Active, DateTime.Now.AddMonths(-18), LoanType.Personal),
            new (2, 2, 350000, 3.2m, 360, LoanStatus.Active, DateTime.Now.AddMonths(-12), LoanType.Mortgage),
            new (3, 3, 15000, 7.8m, 48, LoanStatus.Closed, DateTime.Now.AddMonths(-6), LoanType.Auto),
            new (4, 4, 75000, 4.5m, 120, LoanStatus.Active, DateTime.Now.AddMonths(-24), LoanType.Business),
            new (5, 5, 12000, 6.2m, 36, LoanStatus.Default, DateTime.Now.AddMonths(-8), LoanType.Personal),
            new (6, 6, 45000, 4.8m, 72, LoanStatus.Active, DateTime.Now.AddMonths(-30), LoanType.Business),
            new (7, 7, 20000, 8.5m, 60, LoanStatus.Pending, DateTime.Now.AddDays(-15), LoanType.Auto),
            new (8, 8, 280000, 3.8m, 360, LoanStatus.Active, DateTime.Now.AddMonths(-15), LoanType.Mortgage),
            new (9, 9, 8000, 9.2m, 24, LoanStatus.Closed, DateTime.Now.AddMonths(-4), LoanType.Personal),
            new (10, 10, 55000, 5.1m, 84, LoanStatus.Active, DateTime.Now.AddMonths(-9), LoanType.Business),
            new (11, 1, 18000, 7.5m, 60, LoanStatus.Rejected, DateTime.Now.AddMonths(-3), LoanType.Auto),
            new (12, 3, 30000, 4.2m, 120, LoanStatus.Active, DateTime.Now.AddMonths(-36), LoanType.Student)
        };
}
