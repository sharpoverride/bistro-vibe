using CulinaryVault.Controllers;
using CulinaryVault.Shared;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CulinaryVault.Tests.Unit.Controllers;

public class RecipesControllerTests
{
    private readonly Mock<IRecipeService> _mockRecipeService;
    private readonly RecipesController _controller;

    public RecipesControllerTests()
    {
        _mockRecipeService = new Mock<IRecipeService>();
        _controller = new RecipesController(_mockRecipeService.Object);
    }

    #region GetRecipes Tests

    [Fact]
    public async Task GetRecipes_ReturnsOkWithRecipes()
    {
        // Arrange
        var recipes = new List<Recipe>
        {
            new() { Id = Guid.NewGuid(), Title = "Recipe 1" },
            new() { Id = Guid.NewGuid(), Title = "Recipe 2" }
        };
        _mockRecipeService.Setup(s => s.GetRecipesAsync()).ReturnsAsync(recipes);

        // Act
        var result = await _controller.GetRecipes();

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedRecipes = okResult.Value.Should().BeOfType<List<Recipe>>().Subject;
        returnedRecipes.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetRecipes_EmptyList_ReturnsOkWithEmptyList()
    {
        // Arrange
        _mockRecipeService.Setup(s => s.GetRecipesAsync()).ReturnsAsync(new List<Recipe>());

        // Act
        var result = await _controller.GetRecipes();

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedRecipes = okResult.Value.Should().BeOfType<List<Recipe>>().Subject;
        returnedRecipes.Should().BeEmpty();
    }

    #endregion

    #region GetRecipe Tests

    [Fact]
    public async Task GetRecipe_ExistingId_ReturnsOkWithRecipe()
    {
        // Arrange
        var recipeId = Guid.NewGuid();
        var recipe = new Recipe { Id = recipeId, Title = "Test Recipe" };
        _mockRecipeService.Setup(s => s.GetRecipeByIdAsync(recipeId)).ReturnsAsync(recipe);

        // Act
        var result = await _controller.GetRecipe(recipeId);

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedRecipe = okResult.Value.Should().BeOfType<Recipe>().Subject;
        returnedRecipe.Id.Should().Be(recipeId);
    }

    [Fact]
    public async Task GetRecipe_NonExistingId_ReturnsNotFound()
    {
        // Arrange
        var recipeId = Guid.NewGuid();
        _mockRecipeService.Setup(s => s.GetRecipeByIdAsync(recipeId)).ReturnsAsync((Recipe?)null);

        // Act
        var result = await _controller.GetRecipe(recipeId);

        // Assert
        result.Result.Should().BeOfType<NotFoundResult>();
    }

    #endregion

    #region CreateRecipe Tests

    [Fact]
    public async Task CreateRecipe_ValidRecipe_ReturnsCreatedAtAction()
    {
        // Arrange
        var recipe = new Recipe { Title = "New Recipe" };
        var createdRecipe = new Recipe { Id = Guid.NewGuid(), Title = "New Recipe" };
        _mockRecipeService.Setup(s => s.CreateRecipeAsync(recipe)).ReturnsAsync(createdRecipe);

        // Act
        var result = await _controller.CreateRecipe(recipe);

        // Assert
        var createdResult = result.Result.Should().BeOfType<CreatedAtActionResult>().Subject;
        createdResult.ActionName.Should().Be(nameof(RecipesController.GetRecipe));
        createdResult.RouteValues!["id"].Should().Be(createdRecipe.Id);
    }

    [Fact]
    public async Task CreateRecipe_ReturnsCorrectRecipe()
    {
        // Arrange
        var recipe = new Recipe { Title = "New Recipe" };
        var createdRecipe = new Recipe { Id = Guid.NewGuid(), Title = "New Recipe" };
        _mockRecipeService.Setup(s => s.CreateRecipeAsync(recipe)).ReturnsAsync(createdRecipe);

        // Act
        var result = await _controller.CreateRecipe(recipe);

        // Assert
        var createdResult = result.Result.Should().BeOfType<CreatedAtActionResult>().Subject;
        var returnedRecipe = createdResult.Value.Should().BeOfType<Recipe>().Subject;
        returnedRecipe.Title.Should().Be("New Recipe");
    }

    #endregion

    #region UpdateRecipe Tests

    [Fact]
    public async Task UpdateRecipe_ValidUpdate_ReturnsOkWithUpdatedRecipe()
    {
        // Arrange
        var recipeId = Guid.NewGuid();
        var recipe = new Recipe { Id = recipeId, Title = "Updated Recipe" };
        _mockRecipeService.Setup(s => s.UpdateRecipeAsync(recipe)).ReturnsAsync(recipe);

        // Act
        var result = await _controller.UpdateRecipe(recipeId, recipe);

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedRecipe = okResult.Value.Should().BeOfType<Recipe>().Subject;
        returnedRecipe.Title.Should().Be("Updated Recipe");
    }

    [Fact]
    public async Task UpdateRecipe_IdMismatch_ReturnsBadRequest()
    {
        // Arrange
        var urlId = Guid.NewGuid();
        var recipe = new Recipe { Id = Guid.NewGuid(), Title = "Recipe" };

        // Act
        var result = await _controller.UpdateRecipe(urlId, recipe);

        // Assert
        var badRequestResult = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
        badRequestResult.Value.Should().Be("ID mismatch");
    }

    [Fact]
    public async Task UpdateRecipe_NonExistingRecipe_ReturnsNotFound()
    {
        // Arrange
        var recipeId = Guid.NewGuid();
        var recipe = new Recipe { Id = recipeId, Title = "Recipe" };
        _mockRecipeService.Setup(s => s.UpdateRecipeAsync(recipe))
            .ThrowsAsync(new KeyNotFoundException());

        // Act
        var result = await _controller.UpdateRecipe(recipeId, recipe);

        // Assert
        result.Result.Should().BeOfType<NotFoundResult>();
    }

    #endregion

    #region DeleteRecipe Tests

    [Fact]
    public async Task DeleteRecipe_ReturnsNoContent()
    {
        // Arrange
        var recipeId = Guid.NewGuid();
        _mockRecipeService.Setup(s => s.DeleteRecipeAsync(recipeId)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.DeleteRecipe(recipeId);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task DeleteRecipe_CallsServiceWithCorrectId()
    {
        // Arrange
        var recipeId = Guid.NewGuid();

        // Act
        await _controller.DeleteRecipe(recipeId);

        // Assert
        _mockRecipeService.Verify(s => s.DeleteRecipeAsync(recipeId), Times.Once);
    }

    #endregion

    #region SearchRecipes Tests

    [Fact]
    public async Task SearchRecipes_ReturnsOkWithMatchingRecipes()
    {
        // Arrange
        var recipes = new List<Recipe>
        {
            new() { Id = Guid.NewGuid(), Title = "Apple Pie" }
        };
        _mockRecipeService.Setup(s => s.SearchRecipesAsync("apple")).ReturnsAsync(recipes);

        // Act
        var result = await _controller.SearchRecipes("apple");

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedRecipes = okResult.Value.Should().BeOfType<List<Recipe>>().Subject;
        returnedRecipes.Should().HaveCount(1);
    }

    [Fact]
    public async Task SearchRecipes_NullTerm_UsesEmptyString()
    {
        // Arrange
        _mockRecipeService.Setup(s => s.SearchRecipesAsync("")).ReturnsAsync(new List<Recipe>());

        // Act
        await _controller.SearchRecipes(null!);

        // Assert
        _mockRecipeService.Verify(s => s.SearchRecipesAsync(""), Times.Once);
    }

    #endregion

    #region ToggleFavorite Tests

    [Fact]
    public async Task ToggleFavorite_ExistingRecipe_ReturnsOkWithToggledRecipe()
    {
        // Arrange
        var recipeId = Guid.NewGuid();
        var recipe = new Recipe { Id = recipeId, IsFavorite = true };
        _mockRecipeService.Setup(s => s.ToggleFavoriteAsync(recipeId)).ReturnsAsync(recipe);

        // Act
        var result = await _controller.ToggleFavorite(recipeId);

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedRecipe = okResult.Value.Should().BeOfType<Recipe>().Subject;
        returnedRecipe.IsFavorite.Should().BeTrue();
    }

    [Fact]
    public async Task ToggleFavorite_NonExistingRecipe_ReturnsNotFound()
    {
        // Arrange
        var recipeId = Guid.NewGuid();
        _mockRecipeService.Setup(s => s.ToggleFavoriteAsync(recipeId))
            .ThrowsAsync(new KeyNotFoundException());

        // Act
        var result = await _controller.ToggleFavorite(recipeId);

        // Assert
        result.Result.Should().BeOfType<NotFoundResult>();
    }

    #endregion

    #region GetFavorites Tests

    [Fact]
    public async Task GetFavorites_ReturnsOkWithFavoriteRecipes()
    {
        // Arrange
        var favorites = new List<Recipe>
        {
            new() { Id = Guid.NewGuid(), Title = "Favorite 1", IsFavorite = true },
            new() { Id = Guid.NewGuid(), Title = "Favorite 2", IsFavorite = true }
        };
        _mockRecipeService.Setup(s => s.GetFavoritesAsync()).ReturnsAsync(favorites);

        // Act
        var result = await _controller.GetFavorites();

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedRecipes = okResult.Value.Should().BeOfType<List<Recipe>>().Subject;
        returnedRecipes.Should().HaveCount(2);
    }

    #endregion

    #region GetCuisineTypes Tests

    [Fact]
    public async Task GetCuisineTypes_ReturnsOkWithCuisineTypes()
    {
        // Arrange
        var cuisineTypes = new List<string> { "Italian", "French", "Romanian" };
        _mockRecipeService.Setup(s => s.GetCuisineTypesAsync()).ReturnsAsync(cuisineTypes);

        // Act
        var result = await _controller.GetCuisineTypes();

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedTypes = okResult.Value.Should().BeOfType<List<string>>().Subject;
        returnedTypes.Should().HaveCount(3);
    }

    #endregion

    #region GetRecipesByCuisine Tests

    [Fact]
    public async Task GetRecipesByCuisine_ReturnsOkWithMatchingRecipes()
    {
        // Arrange
        var recipes = new List<Recipe>
        {
            new() { Id = Guid.NewGuid(), Title = "Pasta", CuisineType = "Italian" },
            new() { Id = Guid.NewGuid(), Title = "Pizza", CuisineType = "Italian" }
        };
        _mockRecipeService.Setup(s => s.GetRecipesByCuisineAsync("Italian")).ReturnsAsync(recipes);

        // Act
        var result = await _controller.GetRecipesByCuisine("Italian");

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedRecipes = okResult.Value.Should().BeOfType<List<Recipe>>().Subject;
        returnedRecipes.Should().HaveCount(2);
    }

    #endregion
}
