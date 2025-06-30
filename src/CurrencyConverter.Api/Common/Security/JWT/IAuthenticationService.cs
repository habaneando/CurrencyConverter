using System.Security.Claims;

namespace CurrencyConverter.Api;

public interface IAuthenticationService
{
    Task<User> AuthenticateAsync(string userName, string password, CancellationToken ct);

    Task<List<Claim>> GetUserClaimsAsync(string userId, CancellationToken ct);
}
