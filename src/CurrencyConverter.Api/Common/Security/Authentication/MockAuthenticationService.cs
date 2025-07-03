using System.Security.Claims;

namespace CurrencyConverter.Api;

public class MockAuthenticationService
    : IAuthenticationService
{
    public Task<User> AuthenticateAsync(string userName, string password, CancellationToken ct) =>
        Task.FromResult(
            new User(
                "id1",
                "name1",
                "abc",
                [Role.Admin],
                [Permission.ViewCurrencies],
                [Scope.Read]));
    public Task<List<Claim>> GetUserClaimsAsync(string userId, CancellationToken ct) =>
        Task.FromResult(
            new List<Claim>
            {
                new Claim("Id", "id1"),
                new Claim("Username", "name1"),
                new Claim("Password", "abc"),
                new Claim("Permission", Permission.ViewCurrencies.ToString()),
                new Claim("Scope", Scope.Read.ToString()),
                new Claim("Role", Role.Admin.ToString())
            });
}
