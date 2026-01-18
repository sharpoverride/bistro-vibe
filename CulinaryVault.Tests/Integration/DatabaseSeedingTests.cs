using CulinaryVault.Data;
using CulinaryVault.Tests.TestHelpers;
using Microsoft.EntityFrameworkCore;

namespace CulinaryVault.Tests.Integration;

public class DatabaseSeedingTests : IDisposable
{
    private readonly CulinaryVaultDbContext _context;

    public DatabaseSeedingTests()
    {
        _context = TestDbContextFactory.CreateSqliteContext();
    }

    public void Dispose()
    {
        _context.Database.CloseConnection();
        _context.Dispose();
    }

    [Fact]
    public async Task SeedData_EmptyDatabase_SeedsRecipes()
    {
        // Arrange - Database is empty
        var initialCount = await _context.Recipes.CountAsync();

        // Act
        await SeedData.InitializeAsync(_context);

        // Assert
        var finalCount = await _context.Recipes.CountAsync();
        finalCount.Should().BeGreaterThan(initialCount);
    }

    [Fact]
    public async Task SeedData_NonEmptyDatabase_DoesNotDuplicateRecipes()
    {
        // Arrange - Seed once
        await SeedData.InitializeAsync(_context);
        var firstCount = await _context.Recipes.CountAsync();

        // Act - Try to seed again
        await SeedData.InitializeAsync(_context);
        var secondCount = await _context.Recipes.CountAsync();

        // Assert - Count should remain the same
        secondCount.Should().Be(firstCount);
    }

    [Fact]
    public async Task SeedData_RecipesHaveValidData()
    {
        // Arrange & Act
        await SeedData.InitializeAsync(_context);
        var recipes = await _context.Recipes.ToListAsync();

        // Assert
        recipes.Should().NotBeEmpty();
        recipes.Should().OnlyContain(r => !string.IsNullOrEmpty(r.Title));
        recipes.Should().OnlyContain(r => r.Servings >= 1);
    }

    [Fact]
    public async Task SeedData_RecipesHaveIngredients()
    {
        // Arrange & Act
        await SeedData.InitializeAsync(_context);
        var recipes = await _context.Recipes.ToListAsync();

        // Assert
        recipes.Should().Contain(r => r.Ingredients.Count > 0);
    }

    [Fact]
    public async Task SeedData_RecipesHaveInstructions()
    {
        // Arrange & Act
        await SeedData.InitializeAsync(_context);
        var recipes = await _context.Recipes.ToListAsync();

        // Assert
        recipes.Should().Contain(r => r.Instructions.Count > 0);
    }

    [Fact]
    public async Task SeedData_AllRecipesHaveUniqueIds()
    {
        // Arrange & Act
        await SeedData.InitializeAsync(_context);
        var recipes = await _context.Recipes.ToListAsync();

        // Assert
        recipes.Select(r => r.Id).Should().OnlyHaveUniqueItems();
    }

    [Fact]
    public async Task SeedData_IngredientsHaveUniqueIds()
    {
        // Arrange & Act
        await SeedData.InitializeAsync(_context);
        var recipes = await _context.Recipes.ToListAsync();

        // Assert
        var allIngredientIds = recipes.SelectMany(r => r.Ingredients.Select(i => i.Id)).ToList();
        allIngredientIds.Should().OnlyHaveUniqueItems();
    }

    [Fact]
    public async Task SeedData_InstructionsHaveUniqueIds()
    {
        // Arrange & Act
        await SeedData.InitializeAsync(_context);
        var recipes = await _context.Recipes.ToListAsync();

        // Assert
        var allInstructionIds = recipes.SelectMany(r => r.Instructions.Select(i => i.Id)).ToList();
        allInstructionIds.Should().OnlyHaveUniqueItems();
    }

    [Fact]
    public async Task DatabaseContext_CanCreateAndRetrieveRecipe()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe(title: "Integration Test Recipe");

        // Act
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        _context.ChangeTracker.Clear();
        var retrieved = await _context.Recipes.FindAsync(recipe.Id);

        // Assert
        retrieved.Should().NotBeNull();
        retrieved!.Title.Should().Be("Integration Test Recipe");
    }

    [Fact]
    public async Task DatabaseContext_SerializesIngredientsAsJson()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe();

        // Act
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        _context.ChangeTracker.Clear();
        var retrieved = await _context.Recipes.FindAsync(recipe.Id);

        // Assert
        retrieved!.Ingredients.Should().HaveCount(2);
        retrieved.Ingredients.Should().Contain(i => i.Name == "Ingredient 1");
    }

    [Fact]
    public async Task DatabaseContext_SerializesInstructionsAsJson()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe();

        // Act
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        _context.ChangeTracker.Clear();
        var retrieved = await _context.Recipes.FindAsync(recipe.Id);

        // Assert
        retrieved!.Instructions.Should().HaveCount(2);
        retrieved.Instructions.Should().Contain(i => i.StepNumber == 1);
    }
}
