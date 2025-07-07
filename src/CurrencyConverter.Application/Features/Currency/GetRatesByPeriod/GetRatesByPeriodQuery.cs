namespace CurrencyConverter.Application;

public sealed record GetRatesByPeriodQuery(string StartDate, string EndDate, string Currency, int Page);
