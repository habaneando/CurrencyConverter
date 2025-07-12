namespace CurrencyConverter.Domain;

public class Customer : Entity
{
    public string Name { get; private set; }

    public string Email { get; private set; }

    public int Age { get; private set; }

    public decimal CreditScore { get; private set; }

    public DateTime RegistrationDate { get; private set; }

    public string City { get; private set; }

    public string State { get; private set; }

    public Customer(
        int id,
        string name,
        string email,
        int age,
        decimal creditScore,
        DateTime registrationDate,
        string city,
        string state)
    {
        Id = id;
        Name = name;
        Email = email;
        Age = age;
        CreditScore = creditScore;
        RegistrationDate = registrationDate;
        City = city;
        State = state;
    }

    public bool HasHighCredit(decimal threshold = 750) =>
        CreditScore > threshold;

    public bool IsEligibleForLoan(decimal requestedAmount, LoanType loanType) =>
        CreditScore >= GetMinimumCreditScore(loanType) &&
        Age >= 18;

    public string GetContactInfo() =>
        $"{Name} - {Email}";

    public string GetFullAddress() =>
        $"{City}, {State}";

    public bool IsLongTermCustomer(int yearsThreshold = 2) =>
        DateTime.Now.Subtract(RegistrationDate).TotalDays > (yearsThreshold * 365);

    public CreditRating GetCreditRating() =>
        CreditScore switch
        {
            >= 800 => CreditRating.Excellent,
            >= 740 => CreditRating.VeryGood,
            >= 670 => CreditRating.Good,
            >= 580 => CreditRating.Fair,
            _ => CreditRating.Poor
        };

    public void UpdateCreditScore(decimal newScore)
    {
        if (newScore >= 300 && newScore <= 850)
            CreditScore = newScore;
    }

    private decimal GetMinimumCreditScore(LoanType loanType) =>
        loanType switch
        {
            LoanType.Mortgage => 620,
            LoanType.Auto => 600,
            LoanType.Business => 680,
            LoanType.Personal => 580,
            LoanType.Student => 550,
            _ => 600
        };
}
