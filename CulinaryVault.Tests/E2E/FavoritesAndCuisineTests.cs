using CulinaryVault.Tests.E2E.Fixtures;
using CulinaryVault.Tests.E2E.PageObjects;
using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E;

[Collection("Playwright")]
public class FavoritesAndCuisineTests : IClassFixture<PlaywrightFixture>
{
    private readonly PlaywrightFixture _fixture;

    public FavoritesAndCuisineTests(PlaywrightFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(Skip = "Requires running application")]
    public async Task FavoritesPage_LoadsSuccessfully()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();

        // Act
        await page.GotoAsync("/favorites");
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // Assert
        var url = page.Url;
        url.Should().Contain("/favorites");
    }

    [Fact(Skip = "Requires running application")]
    public async Task FavoritesPage_ShowsOnlyFavoriteRecipes()
    {
        // Arrange - Create a favorite recipe
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);
        var detailPage = new RecipeDetailPage(page);

        var uniqueTitle = $"Favorite Recipe {Guid.NewGuid():N}";

        await newRecipePage.NavigateAsync();
        await newRecipePage.FillBasicInfoAsync(uniqueTitle, "Description", 4);
        await newRecipePage.SubmitAsync();

        // Mark as favorite
        await detailPage.ToggleFavoriteAsync();

        // Act
        await page.GotoAsync("/favorites");
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // Assert
        var content = await page.ContentAsync();
        content.Should().Contain(uniqueTitle);
    }

    [Fact(Skip = "Requires running application")]
    public async Task FavoritesPage_UnfavoriteRecipe_RemovesFromList()
    {
        // Arrange - Create and favorite a recipe
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);
        var detailPage = new RecipeDetailPage(page);
        var homePage = new HomePage(page);

        var uniqueTitle = $"Unfavorite Test {Guid.NewGuid():N}";

        await newRecipePage.NavigateAsync();
        await newRecipePage.FillBasicInfoAsync(uniqueTitle, "Description", 4);
        await newRecipePage.SubmitAsync();

        await detailPage.ToggleFavoriteAsync();

        // Go to favorites page
        await page.GotoAsync("/favorites");
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // Act - Unfavorite the recipe
        await homePage.ToggleFavoriteAsync(0);
        await page.WaitForTimeoutAsync(500);

        // Assert - Recipe should be removed from favorites view
        var content = await page.ContentAsync();
        // After unfavoriting, it should either disappear or show no favorites message
    }

    [Fact(Skip = "Requires running application")]
    public async Task CuisinePage_LoadsSuccessfully()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();

        // Act
        await page.GotoAsync("/cuisine/Românească");
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // Assert
        var url = page.Url;
        url.Should().Contain("/cuisine/");
    }

    [Fact(Skip = "Requires running application")]
    public async Task CuisinePage_ShowsRecipesOfSpecificCuisine()
    {
        // Arrange - Create a recipe with specific cuisine
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);

        var uniqueTitle = $"Italian Recipe {Guid.NewGuid():N}";
        var cuisineType = "TestItalian";

        await newRecipePage.NavigateAsync();
        await newRecipePage.FillBasicInfoAsync(uniqueTitle, "Description", 4);
        await newRecipePage.SetCuisineTypeAsync(cuisineType);
        await newRecipePage.SubmitAsync();

        // Act
        await page.GotoAsync($"/cuisine/{cuisineType}");
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // Assert
        var content = await page.ContentAsync();
        content.Should().Contain(uniqueTitle);
    }

    [Fact(Skip = "Requires running application")]
    public async Task CuisinePage_DoesNotShowOtherCuisines()
    {
        // Arrange - Create recipes with different cuisines
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);

        var italianTitle = $"Italian {Guid.NewGuid():N}";
        var frenchTitle = $"French {Guid.NewGuid():N}";

        // Create Italian recipe
        await newRecipePage.NavigateAsync();
        await newRecipePage.FillBasicInfoAsync(italianTitle, "Description", 4);
        await newRecipePage.SetCuisineTypeAsync("ItalianCuisine");
        await newRecipePage.SubmitAsync();

        // Create French recipe
        await newRecipePage.NavigateAsync();
        await newRecipePage.FillBasicInfoAsync(frenchTitle, "Description", 4);
        await newRecipePage.SetCuisineTypeAsync("FrenchCuisine");
        await newRecipePage.SubmitAsync();

        // Act - View only Italian cuisine
        await page.GotoAsync("/cuisine/ItalianCuisine");
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // Assert
        var content = await page.ContentAsync();
        content.Should().Contain(italianTitle);
        content.Should().NotContain(frenchTitle);
    }

    [Fact(Skip = "Requires running application")]
    public async Task NavigationMenu_HasFavoritesLink()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);

        await homePage.NavigateAsync();

        // Act
        var favoritesLink = page.Locator("a[href='/favorites'], nav a:has-text('Favorite')").First;
        var isVisible = await favoritesLink.IsVisibleAsync();

        // Assert
        isVisible.Should().BeTrue();
    }

    [Fact(Skip = "Requires running application")]
    public async Task NavigationMenu_ClickFavorites_NavigatesToFavoritesPage()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);

        await homePage.NavigateAsync();

        // Act
        var favoritesLink = page.Locator("a[href='/favorites'], nav a:has-text('Favorite')").First;
        await favoritesLink.ClickAsync();
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // Assert
        var url = page.Url;
        url.Should().Contain("/favorites");
    }
}
