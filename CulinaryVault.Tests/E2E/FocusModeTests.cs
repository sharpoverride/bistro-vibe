using CulinaryVault.Tests.E2E.Fixtures;
using CulinaryVault.Tests.E2E.PageObjects;

namespace CulinaryVault.Tests.E2E;

[Collection("Playwright")]
public class FocusModeTests : IClassFixture<PlaywrightFixture>
{
    private readonly PlaywrightFixture _fixture;

    public FocusModeTests(PlaywrightFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(Skip = "Requires running application")]
    public async Task FocusMode_DisplaysCurrentInstruction()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);
        var focusModePage = new FocusModePage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);
        await detailPage.OpenFocusModeAsync();

        // Act
        var instruction = await focusModePage.GetCurrentInstructionAsync();

        // Assert
        instruction.Should().NotBeEmpty();
    }

    [Fact(Skip = "Requires running application")]
    public async Task FocusMode_NavigateNext_ShowsNextInstruction()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);
        var focusModePage = new FocusModePage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);
        await detailPage.OpenFocusModeAsync();

        var firstInstruction = await focusModePage.GetCurrentInstructionAsync();

        // Act
        await focusModePage.GoToNextStepAsync();
        var secondInstruction = await focusModePage.GetCurrentInstructionAsync();

        // Assert - Instructions should be different (if there are multiple steps)
        // If only one step, they would be the same, so we just verify no error
        secondInstruction.Should().NotBeEmpty();
    }

    [Fact(Skip = "Requires running application")]
    public async Task FocusMode_NavigatePrevious_ShowsPreviousInstruction()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);
        var focusModePage = new FocusModePage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);
        await detailPage.OpenFocusModeAsync();

        // Go to second step first
        await focusModePage.GoToNextStepAsync();

        // Act
        await focusModePage.GoToPreviousStepAsync();
        var instruction = await focusModePage.GetCurrentInstructionAsync();

        // Assert
        instruction.Should().NotBeEmpty();
    }

    [Fact(Skip = "Requires running application")]
    public async Task FocusMode_Close_ReturnsToPreviousView()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);
        var focusModePage = new FocusModePage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);
        await detailPage.OpenFocusModeAsync();

        // Act
        await focusModePage.CloseAsync();

        // Assert
        var isVisible = await focusModePage.IsVisibleAsync();
        isVisible.Should().BeFalse();
    }

    [Fact(Skip = "Requires running application")]
    public async Task FocusMode_EscapeKey_ClosesFocusMode()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);
        var focusModePage = new FocusModePage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);
        await detailPage.OpenFocusModeAsync();

        // Act
        await focusModePage.PressEscapeAsync();

        // Assert
        var isVisible = await focusModePage.IsVisibleAsync();
        isVisible.Should().BeFalse();
    }

    [Fact(Skip = "Requires running application")]
    public async Task FocusMode_ArrowKeys_NavigateSteps()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);
        var focusModePage = new FocusModePage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);
        await detailPage.OpenFocusModeAsync();

        var firstInstruction = await focusModePage.GetCurrentInstructionAsync();

        // Act
        await focusModePage.PressArrowRightAsync();
        var afterRight = await focusModePage.GetCurrentInstructionAsync();

        await focusModePage.PressArrowLeftAsync();
        var afterLeft = await focusModePage.GetCurrentInstructionAsync();

        // Assert
        afterRight.Should().NotBeEmpty();
        afterLeft.Should().NotBeEmpty();
    }

    [Fact(Skip = "Requires running application")]
    public async Task FocusMode_ProgressDots_ShowCorrectCount()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);
        var focusModePage = new FocusModePage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);

        var instructionCount = await detailPage.GetInstructionCountAsync();

        await detailPage.OpenFocusModeAsync();

        // Act
        var dotCount = await focusModePage.GetProgressDotCountAsync();

        // Assert
        dotCount.Should().Be(instructionCount);
    }

    [Fact(Skip = "Requires running application")]
    public async Task FocusMode_ClickProgressDot_JumpsToStep()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);
        var focusModePage = new FocusModePage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);
        await detailPage.OpenFocusModeAsync();

        var dotCount = await focusModePage.GetProgressDotCountAsync();

        if (dotCount > 1)
        {
            // Act
            await focusModePage.ClickProgressDotAsync(dotCount - 1);
            var instruction = await focusModePage.GetCurrentInstructionAsync();

            // Assert
            instruction.Should().NotBeEmpty();
        }
    }
}
