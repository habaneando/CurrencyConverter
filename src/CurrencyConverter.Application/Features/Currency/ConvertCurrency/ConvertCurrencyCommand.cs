namespace CurrencyConverter.Application;

public sealed record ConvertCurrencyCommand(string Currency, string Symbols, float Amount);
