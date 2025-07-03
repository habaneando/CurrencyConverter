using System.Security.Claims;
using FastEndpoints.Security;
using Microsoft.IdentityModel.Tokens;

namespace CurrencyConverter.Api;

public class JwtTokenGeneratorService : IJwtTokenGeneratorService
{
    public Task<string> Generate(
        DateTime expireAt,
        string issuer,
        string audience,
        string signingKey,
        List<Claim> claims,
        CancellationToken ct) =>
        Task.FromResult(
            JwtBearer.CreateToken(
                o =>
                {
                    o.ExpireAt = expireAt;
                    o.Issuer = issuer;
                    o.Audience = audience;
                    o.SigningKey = signingKey;
                    o.SigningStyle = TokenSigningStyle.Asymmetric;
                    o.SigningAlgorithm = SecurityAlgorithms.RsaSha256;
                    o.User.Claims.AddRange(claims);
                    o.User.Permissions.AddRange(claims.Where(x => x.Issuer == "Permission").Select(x => x.Value));
                    o.User.Roles.AddRange(claims.Where(x => x.Issuer == "Role").Select(x => x.Value));
                }));
}
