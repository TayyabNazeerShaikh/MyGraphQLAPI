using MyGraphQLAPI.API.ErrorHandling;
using MyGraphQLAPI.Application;
using MyGraphQLAPI.Infrastructure;

namespace MyGraphQLAPI.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders(); // Clear default providers if needed
        builder.Logging.AddConsole(); // Add Console logger
        builder.Logging.AddDebug();   // Add Debug logger

        // Configure minimum log level
        builder.Logging.SetMinimumLevel(LogLevel.Information); // Or read from config

        // --- Dependency Injection ---
        // Register services from Infrastructure layer
        builder.Services.AddInfrastructure(builder.Configuration);
        // Register services from Application layer
        builder.Services.AddApplication();

        // Register Hot Chocolate GraphQL Server
        builder.Services
            .AddGraphQLServer()
            .AddQueryType<Query>()        // This registers the Query class as the root Query type
            .AddMutationType<Mutation>()  // Register the Mutation type
            .AddSorting()                 // Enable sorting feature
            .AddFiltering()               // Enable filtering feature
            .AddInMemorySubscriptions()   // Optional: Add subscriptions (requires AddUseWebSockets)
            .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = builder.Environment.IsDevelopment()) // Show details in dev
            .AddErrorFilter<CustomErrorFilter>();

        // --- ASP.NET Core Services ---
        builder.Services.AddControllers(); // If you need traditional REST controllers alongside GraphQL
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        // --- Middleware ---

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage(); // Detailed errors in Development

            // Initialize the database with seed data in development
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<Infrastructure.Persistence.AppDbContext>();
                // For In-Memory, ensure it's created and seeded
                dbContext.Database.EnsureCreated();
            }
        }
        else
        {
            // Global Exception Handler for production
            app.UseExceptionHandler("/error"); // Redirect to a generic error handling endpoint
            app.UseHsts();
        }

        app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
        

        app.UseRouting();
        
        
        
        app.UseAuthorization(); // If using authentication/authorization

        // Map GraphQL Endpoint
        app.MapGraphQL("/graphql"); // Default GraphQL endpoint

        // Map generic error handling endpoint
        app.MapGet("/error", () => Results.Problem("An unexpected error occurred."));

        app.MapControllers(); // Map traditional REST controllers

        app.Run();
    }
}