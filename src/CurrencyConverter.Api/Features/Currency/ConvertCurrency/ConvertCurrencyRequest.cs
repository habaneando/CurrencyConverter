namespace CurrencyConverter.Api;

internal sealed record ConvertCurrencyRequest(string currency, string symbols, float amount);
