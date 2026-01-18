using CulinaryVault.Data;
using CulinaryVault.Services;
using CulinaryVault.Shared;
using CulinaryVault.Tests.TestHelpers;
using Microsoft.EntityFrameworkCore;

namespace CulinaryVault.Tests.Unit.Services;

public class RecipeServiceTests : IDisposable
{
    private readonly CulinaryVaultDbContext _context;
    private readonly RecipeService _service;

    public RecipeServiceTests()
    {
        _context = TestDbContextFactory.CreateSqliteContext();
        _service = new RecipeService(_context);
    }

    public void Dispose()
    {
        _context.Database.CloseConnection();
        _context.Dispose();
    }

    #region GetRecipesAsync Tests

    [Fact]
    public async Task GetRecipesAsync_EmptyDatabase_ReturnsEmptyList()
    {
        // Act
        var result = await _service.GetRecipesAsync();

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetRecipesAsync_WithRecipes_ReturnsAllRecipes()
    {
        // Arrange
        await TestDbContextFactory.SeedTestDataAsync(_context, 5);

        // Act
        var result = await _service.GetRecipesAsync();

        // Assert
        result.Should().HaveCount(5);
    }

    [Fact]
    public async Task GetRecipesAsync_ReturnsRecipesSortedByTitle()
    {
        // Arrange
        _context.Recipes.AddRange(
            TestDbContextFactory.CreateTestRecipe(title: "Zebra Cake"),
            TestDbContextFactory.CreateTestRecipe(title: "Apple Pie"),
            TestDbContextFactory.CreateTestRecipe(title: "Banana Bread")
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetRecipesAsync();

        // Assert
        result.Should().HaveCount(3);
        result[0].Title.Should().Be("Apple Pie");
        result[1].Title.Should().Be("Banana Bread");
        result[2].Title.Should().Be("Zebra Cake");
    }

    #endregion

    #region GetRecipeByIdAsync Tests

    [Fact]
    public async Task GetRecipeByIdAsync_ExistingId_ReturnsRecipe()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe(title: "Test Recipe");
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetRecipeByIdAsync(recipe.Id);

        // Assert
        result.Should().NotBeNull();
        result!.Title.Should().Be("Test Recipe");
    }

    [Fact]
    public async Task GetRecipeByIdAsync_NonExistingId_ReturnsNull()
    {
        // Act
        var result = await _service.GetRecipeByIdAsync(Guid.NewGuid());

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetRecipeByIdAsync_ReturnsRecipeWithIngredients()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe();
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetRecipeByIdAsync(recipe.Id);

        // Assert
        result.Should().NotBeNull();
        result!.Ingredients.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetRecipeByIdAsync_ReturnsRecipeWithInstructions()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe();
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetRecipeByIdAsync(recipe.Id);

        // Assert
        result.Should().NotBeNull();
        result!.Instructions.Should().HaveCount(2);
    }

    #endregion

    #region CreateRecipeAsync Tests

    [Fact]
    public async Task CreateRecipeAsync_ValidRecipe_ReturnsCreatedRecipe()
    {
        // Arrange
        var recipe = new Recipe
        {
            Title = "New Recipe",
            Description = "Description",
            Servings = 4,
            Ingredients = new List<Ingredient>
            {
                new() { Name = "Ingredient 1", Amount = 100, Unit = "g" }
            },
            Instructions = new List<Instruction>
            {
                new() { StepNumber = 1, Text = "Step 1" }
            }
        };

        // Act
        var result = await _service.CreateRecipeAsync(recipe);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().NotBe(Guid.Empty);
        result.Title.Should().Be("New Recipe");
    }

    [Fact]
    public async Task CreateRecipeAsync_AssignsNewGuidsToIngredients()
    {
        // Arrange
        var recipe = new Recipe
        {
            Title = "New Recipe",
            Ingredients = new List<Ingredient>
            {
                new() { Name = "Ingredient 1", Amount = 100, Unit = "g" },
                new() { Name = "Ingredient 2", Amount = 200, Unit = "g" }
            }
        };

        // Act
        var result = await _service.CreateRecipeAsync(recipe);

        // Assert
        result.Ingredients.Should().HaveCount(2);
        result.Ingredients.Should().OnlyContain(i => i.Id != Guid.Empty);
        result.Ingredients.Select(i => i.Id).Should().OnlyHaveUniqueItems();
    }

    [Fact]
    public async Task CreateRecipeAsync_AssignsNewGuidsToInstructions()
    {
        // Arrange
        var recipe = new Recipe
        {
            Title = "New Recipe",
            Instructions = new List<Instruction>
            {
                new() { StepNumber = 1, Text = "Step 1" },
                new() { StepNumber = 2, Text = "Step 2" }
            }
        };

        // Act
        var result = await _service.CreateRecipeAsync(recipe);

        // Assert
        result.Instructions.Should().HaveCount(2);
        result.Instructions.Should().OnlyContain(i => i.Id != Guid.Empty);
        result.Instructions.Select(i => i.Id).Should().OnlyHaveUniqueItems();
    }

    [Fact]
    public async Task CreateRecipeAsync_PersistsRecipeToDatabase()
    {
        // Arrange
        var recipe = new Recipe { Title = "New Recipe" };

        // Act
        var result = await _service.CreateRecipeAsync(recipe);

        // Assert
        var dbRecipe = await _context.Recipes.FindAsync(result.Id);
        dbRecipe.Should().NotBeNull();
        dbRecipe!.Title.Should().Be("New Recipe");
    }

    [Fact]
    public async Task CreateRecipeAsync_PreservesExistingIngredientGuids()
    {
        // Arrange
        var existingGuid = Guid.NewGuid();
        var recipe = new Recipe
        {
            Title = "New Recipe",
            Ingredients = new List<Ingredient>
            {
                new() { Id = existingGuid, Name = "Ingredient 1", Amount = 100, Unit = "g" }
            }
        };

        // Act
        var result = await _service.CreateRecipeAsync(recipe);

        // Assert
        result.Ingredients.First().Id.Should().Be(existingGuid);
    }

    #endregion

    #region UpdateRecipeAsync Tests

    [Fact]
    public async Task UpdateRecipeAsync_ExistingRecipe_UpdatesSuccessfully()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe(title: "Original Title");
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        recipe.Title = "Updated Title";

        // Act
        var result = await _service.UpdateRecipeAsync(recipe);

        // Assert
        result.Title.Should().Be("Updated Title");
    }

    [Fact]
    public async Task UpdateRecipeAsync_NonExistingRecipe_ThrowsKeyNotFoundException()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe();

        // Act
        var act = () => _service.UpdateRecipeAsync(recipe);

        // Assert
        await act.Should().ThrowAsync<KeyNotFoundException>();
    }

    [Fact]
    public async Task UpdateRecipeAsync_UpdatesAllFields()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe();
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        recipe.Title = "Updated Title";
        recipe.Description = "Updated Description";
        recipe.Servings = 8;
        recipe.IsFavorite = true;
        recipe.CuisineType = "French";

        // Act
        var result = await _service.UpdateRecipeAsync(recipe);

        // Assert
        result.Title.Should().Be("Updated Title");
        result.Description.Should().Be("Updated Description");
        result.Servings.Should().Be(8);
        result.IsFavorite.Should().BeTrue();
        result.CuisineType.Should().Be("French");
    }

    [Fact]
    public async Task UpdateRecipeAsync_PersistsChangesToDatabase()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe(title: "Original");
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        recipe.Title = "Updated";

        // Act
        await _service.UpdateRecipeAsync(recipe);

        // Assert
        _context.ChangeTracker.Clear();
        var dbRecipe = await _context.Recipes.FindAsync(recipe.Id);
        dbRecipe!.Title.Should().Be("Updated");
    }

    #endregion

    #region DeleteRecipeAsync Tests

    [Fact]
    public async Task DeleteRecipeAsync_ExistingRecipe_RemovesFromDatabase()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe();
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        // Act
        await _service.DeleteRecipeAsync(recipe.Id);

        // Assert
        var dbRecipe = await _context.Recipes.FindAsync(recipe.Id);
        dbRecipe.Should().BeNull();
    }

    [Fact]
    public async Task DeleteRecipeAsync_NonExistingRecipe_DoesNotThrow()
    {
        // Act
        var act = () => _service.DeleteRecipeAsync(Guid.NewGuid());

        // Assert
        await act.Should().NotThrowAsync();
    }

    [Fact]
    public async Task DeleteRecipeAsync_DecreasesRecipeCount()
    {
        // Arrange
        await TestDbContextFactory.SeedTestDataAsync(_context, 3);
        var recipes = await _context.Recipes.ToListAsync();
        var recipeToDelete = recipes.First();

        // Act
        await _service.DeleteRecipeAsync(recipeToDelete.Id);

        // Assert
        var count = await _context.Recipes.CountAsync();
        count.Should().Be(2);
    }

    #endregion

    #region SearchRecipesAsync Tests

    [Fact]
    public async Task SearchRecipesAsync_EmptySearchTerm_ReturnsAllRecipes()
    {
        // Arrange
        await TestDbContextFactory.SeedTestDataAsync(_context, 5);

        // Act
        var result = await _service.SearchRecipesAsync("");

        // Assert
        result.Should().HaveCount(5);
    }

    [Fact]
    public async Task SearchRecipesAsync_NullSearchTerm_ReturnsAllRecipes()
    {
        // Arrange
        await TestDbContextFactory.SeedTestDataAsync(_context, 5);

        // Act
        var result = await _service.SearchRecipesAsync(null!);

        // Assert
        result.Should().HaveCount(5);
    }

    [Fact]
    public async Task SearchRecipesAsync_MatchingTitle_ReturnsMatchingRecipes()
    {
        // Arrange
        _context.Recipes.AddRange(
            TestDbContextFactory.CreateTestRecipe(title: "Apple Pie"),
            TestDbContextFactory.CreateTestRecipe(title: "Banana Bread"),
            TestDbContextFactory.CreateTestRecipe(title: "Apple Crumble")
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.SearchRecipesAsync("Apple");

        // Assert
        result.Should().HaveCount(2);
        result.Should().OnlyContain(r => r.Title.Contains("Apple"));
    }

    [Fact]
    public async Task SearchRecipesAsync_MatchingDescription_ReturnsMatchingRecipes()
    {
        // Arrange
        _context.Recipes.AddRange(
            TestDbContextFactory.CreateTestRecipe(title: "Recipe 1", description: "A delicious chocolate cake"),
            TestDbContextFactory.CreateTestRecipe(title: "Recipe 2", description: "A tasty vanilla dessert")
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.SearchRecipesAsync("chocolate");

        // Assert
        result.Should().HaveCount(1);
        result.First().Description.Should().Contain("chocolate");
    }

    [Fact]
    public async Task SearchRecipesAsync_MatchingCuisineType_ReturnsMatchingRecipes()
    {
        // Arrange
        _context.Recipes.AddRange(
            TestDbContextFactory.CreateTestRecipe(title: "Recipe 1", cuisineType: "Italian"),
            TestDbContextFactory.CreateTestRecipe(title: "Recipe 2", cuisineType: "French"),
            TestDbContextFactory.CreateTestRecipe(title: "Recipe 3", cuisineType: "Italian")
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.SearchRecipesAsync("italian");

        // Assert
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task SearchRecipesAsync_MatchingIngredientName_ReturnsMatchingRecipes()
    {
        // Arrange
        var recipeWithChocolate = TestDbContextFactory.CreateTestRecipe(title: "Chocolate Cake");
        recipeWithChocolate.Ingredients = new List<Ingredient>
        {
            new() { Id = Guid.NewGuid(), Name = "Dark Chocolate", Amount = 200, Unit = "g" }
        };

        var recipeWithVanilla = TestDbContextFactory.CreateTestRecipe(title: "Vanilla Cake");
        recipeWithVanilla.Ingredients = new List<Ingredient>
        {
            new() { Id = Guid.NewGuid(), Name = "Vanilla Extract", Amount = 5, Unit = "ml" }
        };

        _context.Recipes.AddRange(recipeWithChocolate, recipeWithVanilla);
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.SearchRecipesAsync("chocolate");

        // Assert
        result.Should().HaveCount(1);
        result.First().Title.Should().Be("Chocolate Cake");
    }

    [Fact]
    public async Task SearchRecipesAsync_CaseInsensitive()
    {
        // Arrange
        _context.Recipes.Add(TestDbContextFactory.CreateTestRecipe(title: "Apple Pie"));
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.SearchRecipesAsync("APPLE");

        // Assert
        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task SearchRecipesAsync_NoMatches_ReturnsEmptyList()
    {
        // Arrange
        await TestDbContextFactory.SeedTestDataAsync(_context, 5);

        // Act
        var result = await _service.SearchRecipesAsync("xyz123nonexistent");

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task SearchRecipesAsync_ReturnsSortedByTitle()
    {
        // Arrange
        _context.Recipes.AddRange(
            TestDbContextFactory.CreateTestRecipe(title: "Zebra Apple Cake"),
            TestDbContextFactory.CreateTestRecipe(title: "Apple Pie"),
            TestDbContextFactory.CreateTestRecipe(title: "Apple Crumble")
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.SearchRecipesAsync("Apple");

        // Assert
        result.Should().BeInAscendingOrder(r => r.Title);
    }

    #endregion

    #region ToggleFavoriteAsync Tests

    [Fact]
    public async Task ToggleFavoriteAsync_UnfavoritedRecipe_SetsFavoriteToTrue()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe(isFavorite: false);
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.ToggleFavoriteAsync(recipe.Id);

        // Assert
        result.IsFavorite.Should().BeTrue();
    }

    [Fact]
    public async Task ToggleFavoriteAsync_FavoritedRecipe_SetsFavoriteToFalse()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe(isFavorite: true);
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.ToggleFavoriteAsync(recipe.Id);

        // Assert
        result.IsFavorite.Should().BeFalse();
    }

    [Fact]
    public async Task ToggleFavoriteAsync_NonExistingRecipe_ThrowsKeyNotFoundException()
    {
        // Act
        var act = () => _service.ToggleFavoriteAsync(Guid.NewGuid());

        // Assert
        await act.Should().ThrowAsync<KeyNotFoundException>();
    }

    [Fact]
    public async Task ToggleFavoriteAsync_PersistsChangeToDatabase()
    {
        // Arrange
        var recipe = TestDbContextFactory.CreateTestRecipe(isFavorite: false);
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        // Act
        await _service.ToggleFavoriteAsync(recipe.Id);

        // Assert
        _context.ChangeTracker.Clear();
        var dbRecipe = await _context.Recipes.FindAsync(recipe.Id);
        dbRecipe!.IsFavorite.Should().BeTrue();
    }

    #endregion

    #region GetFavoritesAsync Tests

    [Fact]
    public async Task GetFavoritesAsync_NoFavorites_ReturnsEmptyList()
    {
        // Arrange
        _context.Recipes.AddRange(
            TestDbContextFactory.CreateTestRecipe(isFavorite: false),
            TestDbContextFactory.CreateTestRecipe(isFavorite: false)
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetFavoritesAsync();

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetFavoritesAsync_WithFavorites_ReturnsFavoritesOnly()
    {
        // Arrange
        _context.Recipes.AddRange(
            TestDbContextFactory.CreateTestRecipe(title: "Favorite 1", isFavorite: true),
            TestDbContextFactory.CreateTestRecipe(title: "Not Favorite", isFavorite: false),
            TestDbContextFactory.CreateTestRecipe(title: "Favorite 2", isFavorite: true)
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetFavoritesAsync();

        // Assert
        result.Should().HaveCount(2);
        result.Should().OnlyContain(r => r.IsFavorite);
    }

    [Fact]
    public async Task GetFavoritesAsync_ReturnsSortedByTitle()
    {
        // Arrange
        _context.Recipes.AddRange(
            TestDbContextFactory.CreateTestRecipe(title: "Zebra", isFavorite: true),
            TestDbContextFactory.CreateTestRecipe(title: "Apple", isFavorite: true)
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetFavoritesAsync();

        // Assert
        result.Should().BeInAscendingOrder(r => r.Title);
    }

    #endregion

    #region GetCuisineTypesAsync Tests

    [Fact]
    public async Task GetCuisineTypesAsync_EmptyDatabase_ReturnsEmptyList()
    {
        // Act
        var result = await _service.GetCuisineTypesAsync();

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetCuisineTypesAsync_ReturnsDistinctCuisineTypes()
    {
        // Arrange
        _context.Recipes.AddRange(
            TestDbContextFactory.CreateTestRecipe(cuisineType: "Italian"),
            TestDbContextFactory.CreateTestRecipe(cuisineType: "French"),
            TestDbContextFactory.CreateTestRecipe(cuisineType: "Italian")
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetCuisineTypesAsync();

        // Assert
        result.Should().HaveCount(2);
        result.Should().Contain("Italian");
        result.Should().Contain("French");
    }

    [Fact]
    public async Task GetCuisineTypesAsync_ReturnsSortedAlphabetically()
    {
        // Arrange
        _context.Recipes.AddRange(
            TestDbContextFactory.CreateTestRecipe(cuisineType: "Zebra"),
            TestDbContextFactory.CreateTestRecipe(cuisineType: "Apple"),
            TestDbContextFactory.CreateTestRecipe(cuisineType: "Middle")
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetCuisineTypesAsync();

        // Assert
        result.Should().BeInAscendingOrder();
    }

    #endregion

    #region GetRecipesByCuisineAsync Tests

    [Fact]
    public async Task GetRecipesByCuisineAsync_MatchingCuisine_ReturnsRecipes()
    {
        // Arrange
        _context.Recipes.AddRange(
            TestDbContextFactory.CreateTestRecipe(title: "Italian 1", cuisineType: "Italian"),
            TestDbContextFactory.CreateTestRecipe(title: "French 1", cuisineType: "French"),
            TestDbContextFactory.CreateTestRecipe(title: "Italian 2", cuisineType: "Italian")
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetRecipesByCuisineAsync("Italian");

        // Assert
        result.Should().HaveCount(2);
        result.Should().OnlyContain(r => r.CuisineType == "Italian");
    }

    [Fact]
    public async Task GetRecipesByCuisineAsync_NoMatches_ReturnsEmptyList()
    {
        // Arrange
        _context.Recipes.Add(TestDbContextFactory.CreateTestRecipe(cuisineType: "Italian"));
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetRecipesByCuisineAsync("French");

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetRecipesByCuisineAsync_ReturnsSortedByTitle()
    {
        // Arrange
        _context.Recipes.AddRange(
            TestDbContextFactory.CreateTestRecipe(title: "Zebra Pasta", cuisineType: "Italian"),
            TestDbContextFactory.CreateTestRecipe(title: "Apple Risotto", cuisineType: "Italian")
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetRecipesByCuisineAsync("Italian");

        // Assert
        result.Should().BeInAscendingOrder(r => r.Title);
    }

    [Fact]
    public async Task GetRecipesByCuisineAsync_IsCaseSensitive()
    {
        // Arrange
        _context.Recipes.Add(TestDbContextFactory.CreateTestRecipe(cuisineType: "Italian"));
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetRecipesByCuisineAsync("italian");

        // Assert
        result.Should().BeEmpty();
    }

    #endregion
}
