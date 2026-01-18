using CulinaryVault.Shared;

namespace CulinaryVault.Tests.Unit.Models;

public class RecipeTests
{
    [Fact]
    public void Recipe_DefaultValues_AreCorrect()
    {
        // Arrange & Act
        var recipe = new Recipe();

        // Assert
        recipe.Id.Should().Be(Guid.Empty);
        recipe.Title.Should().Be(string.Empty);
        recipe.Description.Should().Be(string.Empty);
        recipe.ImageUrl.Should().Be(string.Empty);
        recipe.Servings.Should().Be(4);
        recipe.CuisineType.Should().Be("General");
        recipe.IsFavorite.Should().BeFalse();
        recipe.Difficulty.Should().Be(Difficulty.Easy);
        recipe.Ingredients.Should().NotBeNull().And.BeEmpty();
        recipe.Instructions.Should().NotBeNull().And.BeEmpty();
        recipe.PrepTime.Should().Be(TimeSpan.Zero);
        recipe.CookTime.Should().Be(TimeSpan.Zero);
    }

    [Fact]
    public void Recipe_CanSetAllProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        var recipe = new Recipe
        {
            Id = id,
            Title = "Test Recipe",
            Description = "Test Description",
            ImageUrl = "/uploads/test.png",
            PrepTime = TimeSpan.FromMinutes(15),
            CookTime = TimeSpan.FromMinutes(30),
            Servings = 8,
            Difficulty = Difficulty.Hard,
            CuisineType = "Italian",
            IsFavorite = true
        };

        // Assert
        recipe.Id.Should().Be(id);
        recipe.Title.Should().Be("Test Recipe");
        recipe.Description.Should().Be("Test Description");
        recipe.ImageUrl.Should().Be("/uploads/test.png");
        recipe.PrepTime.Should().Be(TimeSpan.FromMinutes(15));
        recipe.CookTime.Should().Be(TimeSpan.FromMinutes(30));
        recipe.Servings.Should().Be(8);
        recipe.Difficulty.Should().Be(Difficulty.Hard);
        recipe.CuisineType.Should().Be("Italian");
        recipe.IsFavorite.Should().BeTrue();
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

    [Fact]
    public void Recipe_CanAddIngredients()
    {
        // Arrange
        var recipe = new Recipe();
        var ingredient = new Ingredient
        {
            Id = Guid.NewGuid(),
            Name = "Flour",
            Amount = 200,
            Unit = "g",
            Order = 1
        };

        // Act
        recipe.Ingredients.Add(ingredient);

        // Assert
        recipe.Ingredients.Should().HaveCount(1);
        recipe.Ingredients[0].Name.Should().Be("Flour");
    }

    [Fact]
    public void Recipe_CanAddInstructions()
    {
        // Arrange
        var recipe = new Recipe();
        var instruction = new Instruction
        {
            Id = Guid.NewGuid(),
            StepNumber = 1,
            Text = "Mix ingredients"
        };

        // Act
        recipe.Instructions.Add(instruction);

        // Assert
        recipe.Instructions.Should().HaveCount(1);
        recipe.Instructions[0].Text.Should().Be("Mix ingredients");
    }

    [Theory]
    [InlineData(Difficulty.Easy)]
    [InlineData(Difficulty.Medium)]
    [InlineData(Difficulty.Hard)]
    [InlineData(Difficulty.Expert)]
    public void Recipe_CanSetDifficulty(Difficulty difficulty)
    {
        // Arrange & Act
        var recipe = new Recipe { Difficulty = difficulty };

        // Assert
        recipe.Difficulty.Should().Be(difficulty);
    }

    [Fact]
    public void Recipe_IngredientsListIsInitialized()
    {
        // Arrange & Act
        var recipe = new Recipe();

        // Assert
        recipe.Ingredients.Should().NotBeNull();
        recipe.Ingredients.Should().BeOfType<List<Ingredient>>();
    }

    [Fact]
    public void Recipe_InstructionsListIsInitialized()
    {
        // Arrange & Act
        var recipe = new Recipe();

        // Assert
        recipe.Instructions.Should().NotBeNull();
        recipe.Instructions.Should().BeOfType<List<Instruction>>();
    }

    [Fact]
    public void Recipe_Servings_CanBeSetToAnyValue()
    {
        // Arrange & Act
        var recipe = new Recipe { Servings = 100 };

        // Assert
        recipe.Servings.Should().Be(100);
    }
}
