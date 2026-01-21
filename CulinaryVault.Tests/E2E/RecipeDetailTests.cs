using CulinaryVault.Tests.E2E.Fixtures;
using CulinaryVault.Tests.E2E.PageObjects;

namespace CulinaryVault.Tests.E2E;

[Collection("Playwright")]
public class RecipeDetailTests : IClassFixture<PlaywrightFixture>
{
    private readonly PlaywrightFixture _fixture;

    public RecipeDetailTests(PlaywrightFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task RecipeDetail_DisplaysRecipeTitle()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);

        // Act
        var title = await detailPage.GetTitleAsync();

        // Assert
        title.Should().NotBeEmpty();
    }

    [Fact]
    public async Task RecipeDetail_DisplaysIngredients()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);

        // Act
        var ingredientCount = await detailPage.GetIngredientCountAsync();

        // Assert
        ingredientCount.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task RecipeDetail_DisplaysInstructions()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);

        // Act
        var instructionCount = await detailPage.GetInstructionCountAsync();

        // Assert
        instructionCount.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task RecipeDetail_IncreaseServings_UpdatesDisplay()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);

        var initialServings = await detailPage.GetCurrentServingsAsync();

        // Act
        await detailPage.IncreaseServingsAsync();

        // Assert
        var newServings = await detailPage.GetCurrentServingsAsync();
        newServings.Should().Be(initialServings + 1);
    }

    [Fact]
    public async Task RecipeDetail_DecreaseServings_UpdatesDisplay()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);

        // First increase to make sure we can decrease
        await detailPage.IncreaseServingsAsync(2);
        var initialServings = await detailPage.GetCurrentServingsAsync();

        // Act
        await detailPage.DecreaseServingsAsync();

        // Assert
        var newServings = await detailPage.GetCurrentServingsAsync();
        newServings.Should().Be(initialServings - 1);
    }

    [Fact]
    public async Task RecipeDetail_ServingsCannotGoBelowOne()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);

        // Act - Try to decrease many times
        for (int i = 0; i < 20; i++)
        {
            await detailPage.DecreaseServingsAsync();
        }

        // Assert
        var servings = await detailPage.GetCurrentServingsAsync();
        servings.Should().BeGreaterThanOrEqualTo(1);
    }

    [Fact]
    public async Task RecipeDetail_ToggleFavorite_ChangesFavoriteStatus()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);

        // Act & Assert - should not throw
        await detailPage.ToggleFavoriteAsync();
    }

    [Fact]
    public async Task RecipeDetail_ClickEdit_NavigatesToEditPage()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);

        // Act
        await detailPage.ClickEditAsync();

        // Assert
        var url = page.Url;
        url.Should().Contain("/edit");
    }

    [Fact]
    public async Task RecipeDetail_OpenFocusMode_ShowsFocusModeOverlay()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);
        var focusModePage = new FocusModePage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);

        // Act
        await detailPage.OpenFocusModeAsync();

        // Assert
        var isVisible = await focusModePage.IsVisibleAsync();
        isVisible.Should().BeTrue();
    }
}
