namespace CurrencyConverter.Application;

public sealed record ConvertCurrencyCommand(string currency, string symbols, float amount);
