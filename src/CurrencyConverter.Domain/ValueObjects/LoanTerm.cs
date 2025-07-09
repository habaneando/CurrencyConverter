namespace CurrencyConverter.Domain;

// Immutable, self-validating, no ID
public sealed record LoanTerm
{
    public int Months { get; }

    public int Years => Months / 12;

    public LoanTerm(int months)
    {
        if (months <= 0)
            throw new ArgumentException("Term must be positive");

        Months = months;
    }
}
