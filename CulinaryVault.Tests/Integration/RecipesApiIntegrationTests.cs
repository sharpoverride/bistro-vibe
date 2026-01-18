using System.Net;
using System.Net.Http.Json;
using CulinaryVault.Data;
using CulinaryVault.Shared;
using CulinaryVault.Tests.TestHelpers;
using Microsoft.Extensions.DependencyInjection;

namespace CulinaryVault.Tests.Integration;

public class RecipesApiIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;

    public RecipesApiIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    #region GET /api/recipes Tests

    [Fact]
    public async Task GetRecipes_ReturnsSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/api/recipes");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetRecipes_ReturnsJsonContentType()
    {
        // Act
        var response = await _client.GetAsync("/api/recipes");

        // Assert
        response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");
    }

    [Fact]
    public async Task GetRecipes_ReturnsListOfRecipes()
    {
        // Arrange
        await SeedTestDataAsync();

        // Act
        var recipes = await _client.GetFromJsonAsync<List<Recipe>>("/api/recipes");

        // Assert
        recipes.Should().NotBeNull();
        recipes.Should().NotBeEmpty();
    }

    #endregion

    #region GET /api/recipes/{id} Tests

    [Fact]
    public async Task GetRecipe_ExistingId_ReturnsRecipe()
    {
        // Arrange
        var recipeId = await CreateTestRecipeAsync();

        // Act
        var recipe = await _client.GetFromJsonAsync<Recipe>($"/api/recipes/{recipeId}");

        // Assert
        recipe.Should().NotBeNull();
        recipe!.Id.Should().Be(recipeId);
    }

    [Fact]
    public async Task GetRecipe_NonExistingId_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync($"/api/recipes/{Guid.NewGuid()}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    #endregion

    #region POST /api/recipes Tests

    [Fact]
    public async Task CreateRecipe_ValidRecipe_ReturnsCreatedStatus()
    {
        // Arrange
        var recipe = new Recipe
        {
            Title = "Integration Test Recipe",
            Description = "Created during integration test",
            Servings = 4,
            CuisineType = "Test"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/recipes", recipe);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task CreateRecipe_ValidRecipe_ReturnsLocationHeader()
    {
        // Arrange
        var recipe = new Recipe
        {
            Title = "Integration Test Recipe",
            Servings = 4
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/recipes", recipe);

        // Assert
        response.Headers.Location.Should().NotBeNull();
        response.Headers.Location!.ToString().Should().Contain("/api/recipes/");
    }

    [Fact]
    public async Task CreateRecipe_ValidRecipe_CanBeRetrievedById()
    {
        // Arrange
        var recipe = new Recipe
        {
            Title = "Retrievable Recipe",
            Servings = 4
        };

        // Act
        var createResponse = await _client.PostAsJsonAsync("/api/recipes", recipe);
        var createdRecipe = await createResponse.Content.ReadFromJsonAsync<Recipe>();
        var getResponse = await _client.GetFromJsonAsync<Recipe>($"/api/recipes/{createdRecipe!.Id}");

        // Assert
        getResponse.Should().NotBeNull();
        getResponse!.Title.Should().Be("Retrievable Recipe");
    }

    #endregion

    #region PUT /api/recipes/{id} Tests

    [Fact]
    public async Task UpdateRecipe_ValidUpdate_ReturnsOk()
    {
        // Arrange
        var recipeId = await CreateTestRecipeAsync();
        var recipe = await _client.GetFromJsonAsync<Recipe>($"/api/recipes/{recipeId}");
        recipe!.Title = "Updated Title";

        // Act
        var response = await _client.PutAsJsonAsync($"/api/recipes/{recipeId}", recipe);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task UpdateRecipe_IdMismatch_ReturnsBadRequest()
    {
        // Arrange
        var recipeId = await CreateTestRecipeAsync();
        var recipe = new Recipe
        {
            Id = Guid.NewGuid(), // Different ID
            Title = "Test"
        };

        // Act
        var response = await _client.PutAsJsonAsync($"/api/recipes/{recipeId}", recipe);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateRecipe_NonExistingRecipe_ReturnsNotFound()
    {
        // Arrange
        var nonExistingId = Guid.NewGuid();
        var recipe = new Recipe
        {
            Id = nonExistingId,
            Title = "Test"
        };

        // Act
        var response = await _client.PutAsJsonAsync($"/api/recipes/{nonExistingId}", recipe);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    #endregion

    #region DELETE /api/recipes/{id} Tests

    [Fact]
    public async Task DeleteRecipe_ExistingRecipe_ReturnsNoContent()
    {
        // Arrange
        var recipeId = await CreateTestRecipeAsync();

        // Act
        var response = await _client.DeleteAsync($"/api/recipes/{recipeId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteRecipe_ExistingRecipe_RecipeNoLongerExists()
    {
        // Arrange
        var recipeId = await CreateTestRecipeAsync();

        // Act
        await _client.DeleteAsync($"/api/recipes/{recipeId}");
        var getResponse = await _client.GetAsync($"/api/recipes/{recipeId}");

        // Assert
        getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    #endregion

    #region GET /api/recipes/search Tests

    [Fact]
    public async Task SearchRecipes_MatchingTerm_ReturnsMatchingRecipes()
    {
        // Arrange
        await CreateTestRecipeAsync("Apple Pie");
        await CreateTestRecipeAsync("Banana Bread");

        // Act
        var recipes = await _client.GetFromJsonAsync<List<Recipe>>("/api/recipes/search?term=apple");

        // Assert
        recipes.Should().NotBeNull();
        recipes.Should().Contain(r => r.Title.Contains("Apple", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task SearchRecipes_NoMatchingTerm_ReturnsEmptyList()
    {
        // Act
        var recipes = await _client.GetFromJsonAsync<List<Recipe>>("/api/recipes/search?term=xyz123nonexistent");

        // Assert
        recipes.Should().NotBeNull();
        recipes.Should().BeEmpty();
    }

    #endregion

    #region POST /api/recipes/{id}/favorite Tests

    [Fact]
    public async Task ToggleFavorite_ExistingRecipe_ReturnsOk()
    {
        // Arrange
        var recipeId = await CreateTestRecipeAsync();

        // Act
        var response = await _client.PostAsync($"/api/recipes/{recipeId}/favorite", null);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task ToggleFavorite_TogglesIsFavoriteProperty()
    {
        // Arrange
        var recipeId = await CreateTestRecipeAsync();
        var originalRecipe = await _client.GetFromJsonAsync<Recipe>($"/api/recipes/{recipeId}");
        var originalFavorite = originalRecipe!.IsFavorite;

        // Act
        await _client.PostAsync($"/api/recipes/{recipeId}/favorite", null);
        var updatedRecipe = await _client.GetFromJsonAsync<Recipe>($"/api/recipes/{recipeId}");

        // Assert
        updatedRecipe!.IsFavorite.Should().Be(!originalFavorite);
    }

    [Fact]
    public async Task ToggleFavorite_NonExistingRecipe_ReturnsNotFound()
    {
        // Act
        var response = await _client.PostAsync($"/api/recipes/{Guid.NewGuid()}/favorite", null);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    #endregion

    #region GET /api/recipes/favorites Tests

    [Fact]
    public async Task GetFavorites_ReturnsFavoriteRecipesOnly()
    {
        // Arrange
        var recipeId = await CreateTestRecipeAsync();
        await _client.PostAsync($"/api/recipes/{recipeId}/favorite", null);

        // Act
        var favorites = await _client.GetFromJsonAsync<List<Recipe>>("/api/recipes/favorites");

        // Assert
        favorites.Should().NotBeNull();
        favorites.Should().Contain(r => r.Id == recipeId);
    }

    #endregion

    #region GET /api/recipes/cuisine-types Tests

    [Fact]
    public async Task GetCuisineTypes_ReturnsDistinctCuisineTypes()
    {
        // Arrange
        await CreateTestRecipeAsync("Italian Recipe", "Italian");
        await CreateTestRecipeAsync("French Recipe", "French");

        // Act
        var cuisineTypes = await _client.GetFromJsonAsync<List<string>>("/api/recipes/cuisine-types");

        // Assert
        cuisineTypes.Should().NotBeNull();
        cuisineTypes.Should().Contain("Italian");
        cuisineTypes.Should().Contain("French");
    }

    #endregion

    #region GET /api/recipes/cuisine/{cuisineType} Tests

    [Fact]
    public async Task GetRecipesByCuisine_ReturnsMatchingRecipes()
    {
        // Arrange
        await CreateTestRecipeAsync("Pasta", "Italian");
        await CreateTestRecipeAsync("Croissant", "French");

        // Act
        var recipes = await _client.GetFromJsonAsync<List<Recipe>>("/api/recipes/cuisine/Italian");

        // Assert
        recipes.Should().NotBeNull();
        recipes.Should().OnlyContain(r => r.CuisineType == "Italian");
    }

    #endregion

    #region Helper Methods

    private async Task SeedTestDataAsync()
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<CulinaryVaultDbContext>();
        await TestDbContextFactory.SeedTestDataAsync(db, 5);
    }

    private async Task<Guid> CreateTestRecipeAsync(string title = "Test Recipe", string cuisineType = "Test")
    {
        var recipe = new Recipe
        {
            Title = title,
            Description = "Test description",
            Servings = 4,
            CuisineType = cuisineType,
            Ingredients = new List<Ingredient>
            {
                new() { Name = "Test Ingredient", Amount = 100, Unit = "g" }
            },
            Instructions = new List<Instruction>
            {
                new() { StepNumber = 1, Text = "Test step" }
            }
        };

        var response = await _client.PostAsJsonAsync("/api/recipes", recipe);
        var createdRecipe = await response.Content.ReadFromJsonAsync<Recipe>();
        return createdRecipe!.Id;
    }

    #endregion
}
