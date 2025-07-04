﻿namespace CurrencyConverter.Api;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer("Bearer", options =>
        {
            var signingKey = Encoding.UTF8.GetBytes("super-secret-signing-key-1234");

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "mock-issuer",
                ValidateAudience = true,
                ValidAudience = "mock-audience",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                ValidateLifetime = true
            };
        });

        return services;
    }
}
