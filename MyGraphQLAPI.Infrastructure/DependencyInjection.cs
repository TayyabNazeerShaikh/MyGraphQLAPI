// src/MyGraphQLAPI.Infrastructure/DependencyInjection.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyGraphQLAPI.Domain.Interfaces;
using MyGraphQLAPI.Infrastructure.Persistence;
using MyGraphQLAPI.Infrastructure.Repositories;

namespace MyGraphQLAPI.Infrastructure
{
    // Extension method to register infrastructure layer services
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext (Using In-Memory database for this example)
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("MyGraphQLAPIDb"));
            // UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); // For real database

            // Register Repositories
            services.AddScoped<IProductRepository, ProductRepository>();

            // Add other infrastructure services (e.g., external API clients, caching) here

            return services;
        }
    }
}