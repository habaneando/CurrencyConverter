using System.Security.Claims;

namespace CurrencyConverter.Api;

public interface IJwtTokenGeneratorService
{
    Task<string> Generate(
        DateTime expireAt,
        string issuer,
        string audience,
        string signingKey,
        List<Claim> claims,
        CancellationToken ct);
}
