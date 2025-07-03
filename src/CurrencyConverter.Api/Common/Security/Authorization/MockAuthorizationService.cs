namespace CurrencyConverter.Api;

public class MockAuthorizationService
    : IAuthorizationService
{
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
