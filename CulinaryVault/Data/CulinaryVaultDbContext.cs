using System.Text.Json;
using CulinaryVault.Shared;
using Microsoft.EntityFrameworkCore;

namespace CulinaryVault.Data;

public class CulinaryVaultDbContext : DbContext
{
    public DbSet<Recipe> Recipes => Set<Recipe>();

    public CulinaryVaultDbContext(DbContextOptions<CulinaryVaultDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var recipe = modelBuilder.Entity<Recipe>();

        recipe.HasKey(r => r.Id);
        recipe.Property(r => r.Title).IsRequired().HasMaxLength(200);
        recipe.Property(r => r.CuisineType).HasMaxLength(100);
        recipe.Property(r => r.IsFavorite).HasDefaultValue(false);

        // JSON storage for Ingredients via value converters using TEXT
        recipe.Property(r => r.Ingredients)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<Ingredient>>(v, (JsonSerializerOptions?)null) ?? new List<Ingredient>()
            )
            .HasColumnType("TEXT");

        // JSON storage for Instructions via value converters using TEXT
        recipe.Property(r => r.Instructions)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<Instruction>>(v, (JsonSerializerOptions?)null) ?? new List<Instruction>()
            )
            .HasColumnType("TEXT");
    }
}
