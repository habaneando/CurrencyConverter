using Refit;

namespace CurrencyConverter.Api;

internal sealed record GetRatesByCurrencyRequest([Query("currency")] string currency);
