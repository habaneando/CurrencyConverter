namespace CurrencyConverter.Api;

public interface IJwtTokenGeneratorService
{
    Task<string> Generate(string userName, string password, CancellationToken ct);
}
