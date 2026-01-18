using System.ComponentModel.DataAnnotations;
using CulinaryVault.Shared;

namespace CulinaryVault.Tests.Unit.Models;

public class InstructionTests
{
    [Fact]
    public void Instruction_WithValidData_PassesValidation()
    {
        // Arrange
        var instruction = new Instruction
        {
            Id = Guid.NewGuid(),
            StepNumber = 1,
            Text = "Mix all ingredients together"
        };

        // Act
        var validationResults = ValidateModel(instruction);

        // Assert
        validationResults.Should().BeEmpty();
    }

    [Fact]
    public void Instruction_WithoutText_FailsValidation()
    {
        // Arrange
        var instruction = new Instruction
        {
            Id = Guid.NewGuid(),
            StepNumber = 1,
            Text = null!
        };

        // Act
        var validationResults = ValidateModel(instruction);

        // Assert
        validationResults.Should().Contain(r => r.MemberNames.Contains("Text"));
    }

    [Fact]
    public void Instruction_WithEmptyText_FailsValidation()
    {
        // Arrange
        var instruction = new Instruction
        {
            Id = Guid.NewGuid(),
            StepNumber = 1,
            Text = ""
        };

        // Act
        var validationResults = ValidateModel(instruction);

        // Assert
        validationResults.Should().Contain(r => r.MemberNames.Contains("Text"));
    }

    [Fact]
    public void Instruction_DefaultValues_AreCorrect()
    {
        // Arrange & Act
        var instruction = new Instruction();

        // Assert
        instruction.Id.Should().Be(Guid.Empty);
        instruction.StepNumber.Should().Be(0);
        instruction.Text.Should().BeNull();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(100)]
    public void Instruction_WithVariousStepNumbers_PassesValidation(int stepNumber)
    {
        // Arrange
        var instruction = new Instruction
        {
            Id = Guid.NewGuid(),
            StepNumber = stepNumber,
            Text = "Valid instruction text"
        };

        // Act
        var validationResults = ValidateModel(instruction);

        // Assert
        validationResults.Should().BeEmpty();
    }

    [Fact]
    public void Instructions_StepNumberDeterminesSequence()
    {
        // Arrange
        var instructions = new List<Instruction>
        {
            new() { StepNumber = 3, Text = "Third step" },
            new() { StepNumber = 1, Text = "First step" },
            new() { StepNumber = 2, Text = "Second step" }
        };

        // Act
        var ordered = instructions.OrderBy(i => i.StepNumber).ToList();

        // Assert
        ordered[0].Text.Should().Be("First step");
        ordered[1].Text.Should().Be("Second step");
        ordered[2].Text.Should().Be("Third step");
    }

    [Fact]
    public void Instruction_WithLongText_PassesValidation()
    {
        // Arrange
        var longText = new string('A', 1000);
        var instruction = new Instruction
        {
            Id = Guid.NewGuid(),
            StepNumber = 1,
            Text = longText
        };

        // Act
        var validationResults = ValidateModel(instruction);

        // Assert
        validationResults.Should().BeEmpty();
    }

    private static List<ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(model);
        Validator.TryValidateObject(model, validationContext, validationResults, true);
        return validationResults;
    }
}
