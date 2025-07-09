namespace CurrencyConverter.Domain;

// Immutable, self-validating, no ID
public sealed record InterestRate
{
    public decimal Rate { get; }

    public decimal MonthlyRate => Rate / 12m;

    private InterestRate(decimal rate)
    {
        Rate = rate;
    }   

    public static InterestRate Create(decimal rate)
    {
        if (rate< 0)
            throw new ArgumentException("Rate must be non-negative");

        return new InterestRate(rate);
    }
}
