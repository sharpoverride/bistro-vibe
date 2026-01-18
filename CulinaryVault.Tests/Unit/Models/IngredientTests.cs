using CulinaryVault.Shared;

namespace CulinaryVault.Tests.Unit.Models;

public class IngredientTests
{
    [Fact]
    public void Ingredient_DefaultValues_AreCorrect()
    {
        // Arrange & Act
        var ingredient = new Ingredient();

        // Assert
        ingredient.Id.Should().Be(Guid.Empty);
        ingredient.Name.Should().Be(string.Empty);
        ingredient.Amount.Should().Be(0);
        ingredient.Unit.Should().Be(string.Empty);
        ingredient.Order.Should().Be(0);
    }

    [Fact]
    public void Ingredient_CanSetAllProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        var ingredient = new Ingredient
        {
            Id = id,
            Name = "Flour",
            Amount = 200,
            Unit = "g",
            Order = 1
        };

        // Assert
        ingredient.Id.Should().Be(id);
        ingredient.Name.Should().Be("Flour");
        ingredient.Amount.Should().Be(200);
        ingredient.Unit.Should().Be("g");
        ingredient.Order.Should().Be(1);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(0.5)]
    [InlineData(100)]
    [InlineData(1000.5)]
    public void Ingredient_CanSetVariousAmounts(double amount)
    {
        // Arrange & Act
        var ingredient = new Ingredient { Amount = amount };

        // Assert
        ingredient.Amount.Should().Be(amount);
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

    [Fact]
    public void Ingredient_CanHaveVariousUnits()
    {
        // Arrange
        var units = new[] { "g", "kg", "ml", "l", "cup", "tbsp", "tsp", "piece", "bucată" };

        // Act & Assert
        foreach (var unit in units)
        {
            var ingredient = new Ingredient { Unit = unit };
            ingredient.Unit.Should().Be(unit);
        }
    }

    [Fact]
    public void Ingredient_NameCanContainSpecialCharacters()
    {
        // Arrange
        var nameWithSpecialChars = "Brânză de vacă";

        // Act
        var ingredient = new Ingredient { Name = nameWithSpecialChars };

        // Assert
        ingredient.Name.Should().Be(nameWithSpecialChars);
    }

    [Fact]
    public void Ingredient_AmountCanBeFractional()
    {
        // Arrange & Act
        var ingredient = new Ingredient { Amount = 0.25 };

        // Assert
        ingredient.Amount.Should().Be(0.25);
    }
}
