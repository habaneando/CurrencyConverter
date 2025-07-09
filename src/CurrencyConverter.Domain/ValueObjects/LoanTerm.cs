namespace CurrencyConverter.Domain;

// Immutable, self-validating, no ID
public sealed record LoanTerm
{
    public int Months { get; }

    public int Years => Months / 12;

    private LoanTerm(int months)
    {
        Months = months;
    }

    public static LoanTerm Create(int months)
    {
        if (months <= 0)
            throw new ArgumentException("Term must be positive");

        return new LoanTerm(months);
    }
}
