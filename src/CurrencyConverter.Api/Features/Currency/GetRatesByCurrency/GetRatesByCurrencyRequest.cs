using Refit;

namespace CurrencyConverter.Api;

internal sealed record GetRatesByCurrencyRequest([Query] string @base);
