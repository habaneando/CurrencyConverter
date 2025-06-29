namespace CurrencyConverter.Api;

internal sealed record GetRatesByPeriodRequest(string from, string to, string currency);
