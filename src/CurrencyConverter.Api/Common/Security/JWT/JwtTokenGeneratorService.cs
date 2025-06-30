using FastEndpoints.Security;
using Microsoft.IdentityModel.Tokens;

namespace CurrencyConverter.Api;

public class JwtTokenGeneratorService : IJwtTokenGeneratorService
{
    public Task<string> Generate(string userName, string password, CancellationToken ct) =>
        Task.FromResult(
            JwtBearer.CreateToken(
                o =>
                {
                    o.SigningKey = "base64 encoded private key";
                    o.SigningStyle = TokenSigningStyle.Asymmetric;
                    o.SigningAlgorithm = SecurityAlgorithms.RsaSha256;
                    o.Issuer = "issuer";
                    o.Audience = "audience";
                    o.ExpireAt = DateTime.UtcNow.AddDays(1);
                    o.User.Claims.Add(("Claim Type", "Claim Value"));
                    o.User.Permissions.Add("Perm1", "Perm2", "Perm3");
                    o.User.Roles.Add("Role1", "Role2");
                }));
}
