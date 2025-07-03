namespace CurrencyConverter.Api;

public interface IAuthenticationService
{
    Task<User> AuthenticateAsync(string userName, string password, CancellationToken ct);
}
