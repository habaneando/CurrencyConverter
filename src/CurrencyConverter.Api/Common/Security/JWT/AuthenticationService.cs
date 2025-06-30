namespace CurrencyConverter.Api;

public class AuthenticationService : IAuthenticationService
{
    public Task<bool> CredentialsAreValid(string userName, string password, CancellationToken ct) =>
        Task.FromResult(true);
}
