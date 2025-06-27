using CurrencyConverter.Domain;

namespace CurrencyConverter.Api;

internal sealed record GetRatesResponse
{
    public required float Amount { get; init; }

    public required string Base { get; init; }

    public required DateTime Date { get; init; }

    public Rates Rates { get; init; }
}
