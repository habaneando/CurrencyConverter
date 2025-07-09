namespace CurrencyConverter.Domain;

// Immutable, self-validating, no ID
public sealed record InterestRate
{
    public decimal Rate { get; }

    public decimal MonthlyRate => Rate / 12m;

    public InterestRate(decimal rate)
    {
        if (rate< 0)
            throw new ArgumentException("Rate must be non-negative");

        Rate = rate;
    }
}
