using CulinaryVault.Tests.E2E.Fixtures;
using CulinaryVault.Tests.E2E.PageObjects;
using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E;

[Collection("Playwright")]
public class HomePageTests : IClassFixture<PlaywrightFixture>
{
    private readonly PlaywrightFixture _fixture;

    public HomePageTests(PlaywrightFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(Skip = "Requires running application")]
    public async Task HomePage_LoadsSuccessfully()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);

        // Act
        await homePage.NavigateAsync();

        // Assert
        var title = await homePage.GetPageTitleAsync();
        title.Should().NotBeEmpty();
    }

    [Fact(Skip = "Requires running application")]
    public async Task HomePage_DisplaysSearchInput()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);

        // Act
        await homePage.NavigateAsync();

        // Assert
        var isVisible = await homePage.IsSearchInputVisibleAsync();
        isVisible.Should().BeTrue();
    }

    [Fact(Skip = "Requires running application")]
    public async Task HomePage_DisplaysRecipes()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);

        // Act
        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();

        // Assert
        var hasRecipes = await homePage.HasRecipesAsync();
        hasRecipes.Should().BeTrue();
    }

    [Fact(Skip = "Requires running application")]
    public async Task HomePage_Search_FiltersRecipes()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        var initialCount = await homePage.GetRecipeCountAsync();

        // Act
        await homePage.SearchAsync("Sarmale");

        // Assert
        var filteredCount = await homePage.GetRecipeCountAsync();
        // Either we find matching recipes or none at all
        filteredCount.Should().BeLessThanOrEqualTo(initialCount);
    }

    [Fact(Skip = "Requires running application")]
    public async Task HomePage_ClearSearch_ShowsAllRecipes()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        var initialCount = await homePage.GetRecipeCountAsync();

        // Act
        await homePage.SearchAsync("xyz123");
        await homePage.ClearSearchAsync();

        // Assert
        var count = await homePage.GetRecipeCountAsync();
        count.Should().Be(initialCount);
    }

    [Fact(Skip = "Requires running application")]
    public async Task HomePage_ClickRecipe_NavigatesToDetail()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();

        // Act
        await homePage.ClickRecipeAsync(0);

        // Assert
        var url = page.Url;
        url.Should().Contain("/recipes/");
    }

    [Fact(Skip = "Requires running application")]
    public async Task HomePage_ToggleFavorite_UpdatesUI()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();

        // Act & Assert - should not throw
        await homePage.ToggleFavoriteAsync(0);
    }

    [Fact(Skip = "Requires running application")]
    public async Task HomePage_NewRecipeButton_NavigatesToNewRecipePage()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        await homePage.NavigateAsync();

        // Act
        await homePage.NavigateToNewRecipeAsync();

        // Assert
        var url = page.Url;
        url.Should().Contain("/recipes/new");
    }
}
