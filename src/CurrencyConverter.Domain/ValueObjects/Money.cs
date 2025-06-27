namespace CurrencyConverter.Domain;

[ExcludeFromCodeCoverage]
public record Money
{
    public decimal Amount { get; init; }

    public Currency Currency { get; init; }

    private Money(decimal amount, Currency currency)
    {
        (Amount, Currency) = (amount, currency);
    }

    public static Money Create() =>
        new(0, Currency.EUR);

    public static Money Create(decimal amount, Currency currency) =>
        new(amount, currency);
}
