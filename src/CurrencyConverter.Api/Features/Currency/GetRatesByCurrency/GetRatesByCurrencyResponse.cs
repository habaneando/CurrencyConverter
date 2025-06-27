namespace CurrencyConverter.Api;

internal sealed record GetRatesByCurrencyResponse
{
    public required string Base { get; init; }
    
    public required string Date { get; init; }

    public IReadOnlyList<Domain.Money> Rates { get; init; } = [];
}
