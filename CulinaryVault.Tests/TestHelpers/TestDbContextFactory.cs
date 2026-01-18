using CulinaryVault.Data;
using CulinaryVault.Shared;
using Microsoft.EntityFrameworkCore;

namespace CulinaryVault.Tests.TestHelpers;

public static class TestDbContextFactory
{
    public static CulinaryVaultDbContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<CulinaryVaultDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new CulinaryVaultDbContext(options);
    }

    public static CulinaryVaultDbContext CreateSqliteContext()
    {
        var options = new DbContextOptionsBuilder<CulinaryVaultDbContext>()
            .UseSqlite("DataSource=:memory:")
            .Options;

        var context = new CulinaryVaultDbContext(options);
        context.Database.OpenConnection();
        context.Database.EnsureCreated();
        return context;
    }

    public static Recipe CreateTestRecipe(
        string title = "Test Recipe",
        string description = "Test Description",
        string cuisineType = "Test Cuisine",
        bool isFavorite = false,
        int servings = 4)
    {
        return new Recipe
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            ImageUrl = "/uploads/test.png",
            PrepTime = TimeSpan.FromMinutes(15),
            CookTime = TimeSpan.FromMinutes(30),
            Servings = servings,
            Difficulty = Difficulty.Medium,
            CuisineType = cuisineType,
            IsFavorite = isFavorite,
            Ingredients = new List<Ingredient>
            {
                new() { Id = Guid.NewGuid(), Name = "Ingredient 1", Amount = 100, Unit = "g", Order = 1 },
                new() { Id = Guid.NewGuid(), Name = "Ingredient 2", Amount = 2, Unit = "cups", Order = 2 }
            },
            Instructions = new List<Instruction>
            {
                new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Step 1 instructions" },
                new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Step 2 instructions" }
            }
        };
    }

    public static async Task SeedTestDataAsync(CulinaryVaultDbContext context, int count = 5)
    {
        var recipes = Enumerable.Range(1, count)
            .Select(i => CreateTestRecipe(
                title: $"Recipe {i}",
                cuisineType: i % 2 == 0 ? "Italian" : "Romanian",
                isFavorite: i % 3 == 0))
            .ToList();

        context.Recipes.AddRange(recipes);
        await context.SaveChangesAsync();
    }
}
