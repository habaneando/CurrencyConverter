namespace CurrencyConverter.Domain;

public class LoanService : ILoanService
{
    private readonly ICustomerRepository _customerRepo;

    private readonly ILoanRepository _loanRepo;

    private readonly IPaymentRepository _paymentRepo;

    public LoanService(
        ICustomerRepository customerRepo,
        ILoanRepository loanRepo,
        IPaymentRepository paymentRepo)
    {
        _customerRepo = customerRepo;

        _loanRepo = loanRepo;

        _paymentRepo = paymentRepo;
    }

    public IEnumerable<object> GetCustomerLoansWithDetails()
    {
        var loans = _loanRepo.GetByStatus(LoanStatus.Active);

        return from customer in _customerRepo.GetPaginated(1, 100)
               join loan in loans on customer.Id equals loan.CustomerId
               select new
               {
                   CustomerName = customer.Name,
                   CustomerRating = customer.GetCreditRating(),
                   LoanAmount = loan.Amount,
                   MonthlyPayment = loan.CalculateMonthlyPayment(),
                   LoanType = loan.Type,
                   RiskLevel = loan.GetRiskLevel()
               };
    }

    public IEnumerable<object> GetTopCustomersByLoanAmount(int count = 3)
    {
        var allCustomers = _customerRepo.GetPaginated(1, 1000);

        var allLoans = _loanRepo.GetByStatus(LoanStatus.Active).Concat(_loanRepo.GetByStatus(LoanStatus.Closed));

        return from customer in allCustomers
               join loan in allLoans on customer.Id equals loan.CustomerId into customerLoans
               let totalLoanAmount = customerLoans.Sum(l => l.Amount)
               let loanCount = customerLoans.Count()
               where loanCount > 0
               orderby totalLoanAmount descending
               select new
               {
                   Customer = customer.Name,
                   CreditRating = customer.GetCreditRating(),
                   TotalLoanAmount = totalLoanAmount,
                   LoanCount = loanCount,
                   IsLongTermCustomer = customer.IsLongTermCustomer()
               }
               into result
               select result;
    }

    public bool CanApproveNewLoan(
        int customerId,
        decimal requestedAmount,
        LoanType loanType)
    {
        var customer = _customerRepo.GetById(customerId);

        if (customer == null) return false;

        var existingLoans = _loanRepo.GetByCustomer(customerId).Where(l => l.IsActive());

        var totalExistingAmount = existingLoans.Sum(l => l.Amount);

        return customer.IsEligibleForLoan(requestedAmount, loanType) &&
               (totalExistingAmount + requestedAmount) <= GetMaxLoanLimit(customer.GetCreditRating());
    }

    private decimal GetMaxLoanLimit(CreditRating rating) =>
        rating switch
        {
            CreditRating.Excellent => 1000000,
            CreditRating.VeryGood => 500000,
            CreditRating.Good => 250000,
            CreditRating.Fair => 100000,
            CreditRating.Poor => 25000,
            _ => 25000
        };

    public decimal CalculateMaxLoanLimit(Customer customer)
    {
        var baseLimit = customer.GetCreditRating() switch
        {
            CreditRating.Excellent => 1000000m,
            CreditRating.VeryGood => 500000m,
            CreditRating.Good => 250000m,
            CreditRating.Fair => 100000m,
            CreditRating.Poor => 25000m,
            _ => 25000m
        };

        // Adjust based on customer tenure - long-term customers get 20% bonus
        if (customer.IsLongTermCustomer(3))
            baseLimit *= 1.2m;

        // Adjust based on age - customers 40+ get stability bonus
        if (customer.Age >= 40)
            baseLimit *= 1.1m;

        // Check existing loan performance
        var existingLoans = _loanRepo.GetByCustomer(customer.Id);

        var hasDefaultHistory = existingLoans.Any(l => l.Status == LoanStatus.Default);

        if (hasDefaultHistory)
            baseLimit *= 0.5m; // Reduce limit by 50% for default history

        return Math.Round(baseLimit, 2);
    }

    public bool IsCustomerEligibleForRefinancing(
        int customerId,
        decimal newAmount,
        decimal newRate)
    {
        var customer = _customerRepo.GetById(customerId);

        if (customer == null) return false;

        // Must have good credit score (700+)
        if (!customer.HasHighCredit(700)) return false;

        var existingLoans = _loanRepo.GetByCustomer(customerId).Where(l => l.IsActive());

        if (!existingLoans.Any()) return false; // No active loans to refinance

        // Check payment history - no late payments in last 12 months
        var recentPayments = _paymentRepo.GetByDateRange(DateTime.Now.AddMonths(-12), DateTime.Now)

            .Where(p => existingLoans.Any(l => l.Id == p.LoanId));

        var hasGoodPaymentHistory = !recentPayments.Any(p => p.IsLatePayment());

        if (!hasGoodPaymentHistory) return false;

        // New amount cannot exceed current max loan limit
        var maxLimit = CalculateMaxLoanLimit(customer);

        if (newAmount > maxLimit) return false;

        // New rate must be lower than average current rate (refinancing benefit)
        var currentAverageRate = existingLoans.Average(l => l.InterestRate);

        if (newRate >= currentAverageRate) return false;

        // Customer must be long-term (at least 1 year)
        return customer.IsLongTermCustomer(1);
    }

    public object GetCustomerRiskProfile(int customerId)
    {
        var customer = _customerRepo.GetById(customerId);

        if (customer == null) return null;

        var allLoans = _loanRepo.GetByCustomer(customerId);
        var activeLoans = allLoans.Where(l => l.IsActive());
        var closedLoans = allLoans.Where(l => l.Status == LoanStatus.Closed);
        var defaultLoans = allLoans.Where(l => l.Status == LoanStatus.Default);

        // Get all payments for this customer's loans
        var allPayments = allLoans.SelectMany(l => _paymentRepo.GetByLoan(l.Id));
        var latePayments = allPayments.Where(p => p.IsLatePayment());
        var recentLatePayments = latePayments.Where(p => p.IsRecentPayment(90)); // Last 90 days

        // Calculate financial metrics
        var totalActiveAmount = activeLoans.Sum(l => l.Amount);
        var totalPaidAmount = allPayments.Sum(p => p.Amount);
        var totalLateFees = latePayments.Sum(p => p.CalculateLateFee());
        var averageInterestRate = activeLoans.Any() ? activeLoans.Average(l => l.InterestRate) : 0;

        // Calculate debt-to-limit ratio
        var maxLimit = CalculateMaxLoanLimit(customer);
        var debtToLimitRatio = maxLimit > 0 ? (totalActiveAmount / maxLimit) * 100 : 0;

        return new
        {
            CustomerId = customerId,
            CustomerName = customer.Name,
            CreditRating = customer.GetCreditRating(),
            CreditScore = customer.CreditScore,

            // Loan Portfolio
            TotalActiveLoans = activeLoans.Count(),
            TotalActiveLoanAmount = totalActiveAmount,
            TotalClosedLoans = closedLoans.Count(),
            TotalDefaultLoans = defaultLoans.Count(),
            AverageInterestRate = Math.Round(averageInterestRate, 2),

            // Payment History
            TotalPayments = allPayments.Count(),
            LatePaymentCount = latePayments.Count(),
            RecentLatePayments = recentLatePayments.Count(),
            TotalLateFees = totalLateFees,
            PaymentReliabilityScore = CalculatePaymentReliabilityScore(allPayments.Count(), latePayments.Count()),

            // Risk Assessment
            RiskLevel = DetermineRiskLevel(customer, latePayments.Count(), totalActiveAmount, defaultLoans.Any()),
            DebtToLimitRatio = Math.Round(debtToLimitRatio, 1),
            MaxLoanLimit = maxLimit,

            // Customer Profile
            IsLongTermCustomer = customer.IsLongTermCustomer(),
            CustomerTenureYears = Math.Round((DateTime.Now - customer.RegistrationDate).TotalDays / 365, 1),
            EligibleForRefinancing = IsCustomerEligibleForRefinancing(customerId, totalActiveAmount, averageInterestRate - 1)
        };
    }

    private decimal CalculatePaymentReliabilityScore(int totalPayments, int latePayments)
    {
        if (totalPayments == 0) return 100; 

        var onTimePercentage = ((decimal)(totalPayments - latePayments) / totalPayments) * 100;

        return Math.Round(onTimePercentage, 1);
    }

    private string DetermineRiskLevel(
        Customer customer,
        int latePaymentCount,
        decimal totalLoanAmount,
        bool hasDefaultHistory)
    {
        // High Risk Criteria
        if (hasDefaultHistory) return "High Risk";
        if (customer.GetCreditRating() == CreditRating.Poor) return "High Risk";
        if (latePaymentCount > 5) return "High Risk";
        if (totalLoanAmount > 500000 && customer.GetCreditRating() < CreditRating.VeryGood) return "High Risk";

        // Medium Risk Criteria  
        if (latePaymentCount > 2) return "Medium Risk";
        if (totalLoanAmount > 200000) return "Medium Risk";
        if (customer.GetCreditRating() == CreditRating.Fair) return "Medium Risk";
        if (!customer.IsLongTermCustomer(1)) return "Medium Risk"; // New customers

        // Low Risk - Good credit, payment history, and relationship
        return "Low Risk";
    }
}
