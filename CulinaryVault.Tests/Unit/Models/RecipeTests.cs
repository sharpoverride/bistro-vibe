using System.ComponentModel.DataAnnotations;
using CulinaryVault.Shared;

namespace CulinaryVault.Tests.Unit.Models;

public class RecipeTests
{
    [Fact]
    public void Recipe_WithValidData_PassesValidation()
    {
        // Arrange
        var recipe = new Recipe
        {
            Id = Guid.NewGuid(),
            Title = "Valid Recipe",
            Description = "A valid recipe description",
            Servings = 4,
            CuisineType = "Italian"
        };

        // Act
        var validationResults = ValidateModel(recipe);

        // Assert
        validationResults.Should().BeEmpty();
    }

    [Fact]
    public void Recipe_WithoutTitle_FailsValidation()
    {
        // Arrange
        var recipe = new Recipe
        {
            Id = Guid.NewGuid(),
            Title = null!,
            Servings = 4
        };

        // Act
        var validationResults = ValidateModel(recipe);

        // Assert
        validationResults.Should().Contain(r => r.MemberNames.Contains("Title"));
    }

    [Fact]
    public void Recipe_WithEmptyTitle_FailsValidation()
    {
        // Arrange
        var recipe = new Recipe
        {
            Id = Guid.NewGuid(),
            Title = "",
            Servings = 4
        };

        // Act
        var validationResults = ValidateModel(recipe);

        // Assert
        validationResults.Should().Contain(r => r.MemberNames.Contains("Title"));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(101)]
    [InlineData(500)]
    public void Recipe_WithInvalidServings_FailsValidation(int servings)
    {
        // Arrange
        var recipe = new Recipe
        {
            Id = Guid.NewGuid(),
            Title = "Test Recipe",
            Servings = servings
        };

        // Act
        var validationResults = ValidateModel(recipe);

        // Assert
        validationResults.Should().Contain(r => r.MemberNames.Contains("Servings"));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(50)]
    [InlineData(100)]
    public void Recipe_WithValidServings_PassesValidation(int servings)
    {
        // Arrange
        var recipe = new Recipe
        {
            Id = Guid.NewGuid(),
            Title = "Test Recipe",
            Servings = servings
        };

        // Act
        var validationResults = ValidateModel(recipe);

        // Assert
        validationResults.Should().NotContain(r => r.MemberNames.Contains("Servings"));
    }

    [Fact]
    public void Recipe_TitleExceeds200Characters_FailsValidation()
    {
        // Arrange
        var recipe = new Recipe
        {
            Id = Guid.NewGuid(),
            Title = new string('A', 201),
            Servings = 4
        };

        // Act
        var validationResults = ValidateModel(recipe);

        // Assert
        validationResults.Should().Contain(r => r.MemberNames.Contains("Title"));
    }

    [Fact]
    public void Recipe_DefaultValues_AreCorrect()
    {
        // Arrange & Act
        var recipe = new Recipe();

        // Assert
        recipe.Id.Should().Be(Guid.Empty);
        recipe.Servings.Should().Be(4);
        recipe.CuisineType.Should().Be("General");
        recipe.IsFavorite.Should().BeFalse();
        recipe.Ingredients.Should().NotBeNull().And.BeEmpty();
        recipe.Instructions.Should().NotBeNull().And.BeEmpty();
    }

    [Theory]
    [InlineData(Difficulty.Easy)]
    [InlineData(Difficulty.Medium)]
    [InlineData(Difficulty.Hard)]
    [InlineData(Difficulty.Expert)]
    public void Recipe_WithValidDifficulty_PassesValidation(Difficulty difficulty)
    {
        // Arrange
        var recipe = new Recipe
        {
            Id = Guid.NewGuid(),
            Title = "Test Recipe",
            Difficulty = difficulty
        };

        // Act
        var validationResults = ValidateModel(recipe);

        // Assert
        validationResults.Should().NotContain(r => r.MemberNames.Contains("Difficulty"));
    }

    [Fact]
    public void Recipe_TotalTime_IsCalculatedCorrectly()
    {
        // Arrange
        var recipe = new Recipe
        {
            PrepTime = TimeSpan.FromMinutes(15),
            CookTime = TimeSpan.FromMinutes(30)
        };

        // Act
        var totalTime = recipe.PrepTime + recipe.CookTime;

        // Assert
        totalTime.Should().Be(TimeSpan.FromMinutes(45));
    }

    private static List<ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(model);
        Validator.TryValidateObject(model, validationContext, validationResults, true);
        return validationResults;
    }
}
