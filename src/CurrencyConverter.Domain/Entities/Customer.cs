namespace CurrencyConverter.Domain;

public class Customer : Entity
{
    public string Name { get; init; }

    public string Email { get; init; }

    public int Age { get; init; }

    public decimal CreditScore { get; init; }

    public DateTime RegistrationDate { get; init; }

    public string City { get; init; }

    public string State { get; init; }

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
}
