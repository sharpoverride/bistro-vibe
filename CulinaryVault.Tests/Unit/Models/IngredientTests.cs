using System.ComponentModel.DataAnnotations;
using CulinaryVault.Shared;

namespace CulinaryVault.Tests.Unit.Models;

public class IngredientTests
{
    [Fact]
    public void Ingredient_WithValidData_PassesValidation()
    {
        // Arrange
        var ingredient = new Ingredient
        {
            Id = Guid.NewGuid(),
            Name = "Flour",
            Amount = 200,
            Unit = "g",
            Order = 1
        };

        // Act
        var validationResults = ValidateModel(ingredient);

        // Assert
        validationResults.Should().BeEmpty();
    }

    [Fact]
    public void Ingredient_WithoutName_FailsValidation()
    {
        // Arrange
        var ingredient = new Ingredient
        {
            Id = Guid.NewGuid(),
            Name = null!,
            Amount = 100,
            Unit = "g"
        };

        // Act
        var validationResults = ValidateModel(ingredient);

        // Assert
        validationResults.Should().Contain(r => r.MemberNames.Contains("Name"));
    }

    [Fact]
    public void Ingredient_WithEmptyName_FailsValidation()
    {
        // Arrange
        var ingredient = new Ingredient
        {
            Id = Guid.NewGuid(),
            Name = "",
            Amount = 100,
            Unit = "g"
        };

        // Act
        var validationResults = ValidateModel(ingredient);

        // Assert
        validationResults.Should().Contain(r => r.MemberNames.Contains("Name"));
    }

    [Fact]
    public void Ingredient_DefaultValues_AreCorrect()
    {
        // Arrange & Act
        var ingredient = new Ingredient();

        // Assert
        ingredient.Id.Should().Be(Guid.Empty);
        ingredient.Name.Should().BeNull();
        ingredient.Amount.Should().Be(0);
        ingredient.Unit.Should().BeNull();
        ingredient.Order.Should().Be(0);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(0.5)]
    [InlineData(100)]
    [InlineData(1000.5)]
    public void Ingredient_WithVariousAmounts_PassesValidation(double amount)
    {
        // Arrange
        var ingredient = new Ingredient
        {
            Id = Guid.NewGuid(),
            Name = "Test Ingredient",
            Amount = amount,
            Unit = "g"
        };

        // Act
        var validationResults = ValidateModel(ingredient);

        // Assert
        validationResults.Should().BeEmpty();
    }

    [Fact]
    public void Ingredient_OrderDeterminesSequence()
    {
        // Arrange
        var ingredients = new List<Ingredient>
        {
            new() { Name = "Third", Order = 3 },
            new() { Name = "First", Order = 1 },
            new() { Name = "Second", Order = 2 }
        };

        // Act
        var ordered = ingredients.OrderBy(i => i.Order).ToList();

        // Assert
        ordered[0].Name.Should().Be("First");
        ordered[1].Name.Should().Be("Second");
        ordered[2].Name.Should().Be("Third");
    }

    private static List<ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(model);
        Validator.TryValidateObject(model, validationContext, validationResults, true);
        return validationResults;
    }
}
