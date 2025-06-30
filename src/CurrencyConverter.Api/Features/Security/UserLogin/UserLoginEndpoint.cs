using FastEndpoints;

namespace CurrencyConverter.Api;

public class UserLoginEndpoint(
    IAuthenticationService AuthenticationService,
    IJwtTokenGeneratorService JwtTokenGeneratorService)
    : Endpoint<UserLoginRequest>
{
    public override void Configure()
    {
        Post("/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UserLoginRequest userLoginRequest, CancellationToken ct)
    {
        if (await AuthenticationService.AuthenticateAsync(
            userLoginRequest.Username,
            userLoginRequest.Password,
            ct) is not null)
        {
            await SendAsync(
                JwtTokenGeneratorService.Generate(
                    userLoginRequest.Username,
                    userLoginRequest.Password,
                    ct));
        }
        else
            ThrowError("The supplied credentials are invalid!");
    }
}
