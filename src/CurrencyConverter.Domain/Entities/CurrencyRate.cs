
namespace CurrencyConverter.Domain;

public record CurrencyRate(string Base, string Date, IReadOnlyList<Money> Rates);

