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
}
