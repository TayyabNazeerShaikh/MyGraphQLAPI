// src/MyGraphQLAPI.Application/DependencyInjection.cs
using Microsoft.Extensions.DependencyInjection;
using MyGraphQLAPI.Application.Interfaces;
using MyGraphQLAPI.Application.Services;

namespace MyGraphQLAPI.Application
{
    // Extension method to register application layer services
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            // Add other application services here

            return services;
        }
    }
}