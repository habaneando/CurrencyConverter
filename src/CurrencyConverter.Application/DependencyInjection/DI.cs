﻿using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Application;

public static class DI
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
