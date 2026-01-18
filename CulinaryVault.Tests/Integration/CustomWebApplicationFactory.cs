using CulinaryVault.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CulinaryVault.Tests.Integration;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove all DbContext registrations
            var descriptorsToRemove = services
                .Where(d => d.ServiceType == typeof(DbContextOptions<CulinaryVaultDbContext>) ||
                           d.ServiceType == typeof(CulinaryVaultDbContext) ||
                           d.ServiceType.FullName?.Contains("EntityFrameworkCore") == true)
                .ToList();

            foreach (var descriptor in descriptorsToRemove)
            {
                services.Remove(descriptor);
            }

            // Add SQLite in-memory database for testing
            var connectionString = $"DataSource=file:test_{Guid.NewGuid():N}?mode=memory&cache=shared";

            services.AddDbContext<CulinaryVaultDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            // Build the service provider
            var sp = services.BuildServiceProvider();

            // Create the database and apply migrations
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<CulinaryVaultDbContext>();
            db.Database.OpenConnection();
            db.Database.EnsureCreated();
        });

        builder.UseEnvironment("Testing");
    }
}
