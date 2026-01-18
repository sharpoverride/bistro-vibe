using CulinaryVault.Shared;

namespace CulinaryVault.Tests.Unit.Models;

public class InstructionTests
{
    [Fact]
    public void Instruction_DefaultValues_AreCorrect()
    {
        // Arrange & Act
        var instruction = new Instruction();

        // Assert
        instruction.Id.Should().Be(Guid.Empty);
        instruction.StepNumber.Should().Be(0);
        instruction.Text.Should().Be(string.Empty);
    }

    [Fact]
    public void Instruction_CanSetAllProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        var instruction = new Instruction
        {
            Id = id,
            StepNumber = 1,
            Text = "Mix all ingredients together"
        };

        // Assert
        instruction.Id.Should().Be(id);
        instruction.StepNumber.Should().Be(1);
        instruction.Text.Should().Be("Mix all ingredients together");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(100)]
    public void Instruction_CanSetVariousStepNumbers(int stepNumber)
    {
        // Arrange & Act
        var instruction = new Instruction { StepNumber = stepNumber };

        // Assert
        instruction.StepNumber.Should().Be(stepNumber);
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
    public void Instruction_CanHaveLongText()
    {
        // Arrange
        var longText = new string('A', 1000);

        // Act
        var instruction = new Instruction { Text = longText };

        // Assert
        instruction.Text.Should().Be(longText);
        instruction.Text.Length.Should().Be(1000);
    }

    [Fact]
    public void Instruction_TextCanContainSpecialCharacters()
    {
        // Arrange
        var textWithSpecialChars = "Bake at 180°C for 30 minutes. Use 1/2 cup flour.";

        // Act
        var instruction = new Instruction { Text = textWithSpecialChars };

        // Assert
        instruction.Text.Should().Be(textWithSpecialChars);
    }

    [Fact]
    public void Instruction_CanHaveMultilineText()
    {
        // Arrange
        var multilineText = "First do this.\nThen do that.\nFinally, complete it.";

        // Act
        var instruction = new Instruction { Text = multilineText };

        // Assert
        instruction.Text.Should().Contain("\n");
    }
}
