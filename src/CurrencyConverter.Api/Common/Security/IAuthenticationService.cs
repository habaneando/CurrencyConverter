namespace CurrencyConverter.Api;

public interface IAuthenticationService
{
    Task<bool> CredentialsAreValid(string userName, string password, CancellationToken ct);
}
