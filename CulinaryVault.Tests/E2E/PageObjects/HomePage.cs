using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E.PageObjects;

public class HomePage
{
    private readonly IPage _page;

    public HomePage(IPage page)
    {
        _page = page;
    }

    // Selectors using data-testid
    private ILocator SearchInput => _page.Locator("[data-testid='search-input']");
    private ILocator RecipeGrid => _page.Locator("[data-testid='recipe-grid']");
    private ILocator RecipeCards => _page.Locator("[data-testid='recipe-card']");
    private ILocator NewRecipeButton => _page.Locator("[data-testid='new-recipe-button'], a[href='/recipes/new']");

    public async Task NavigateAsync()
    {
        await _page.GotoAsync("/");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task SearchAsync(string term)
    {
        await SearchInput.FillAsync(term);
        // Wait for debounce (300ms in the app)
        await _page.WaitForTimeoutAsync(400);
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task ClearSearchAsync()
    {
        await SearchInput.ClearAsync();
        await _page.WaitForTimeoutAsync(400);
    }

    public async Task<int> GetRecipeCountAsync()
    {
        await _page.WaitForTimeoutAsync(500);
        return await RecipeCards.CountAsync();
    }

    public async Task<bool> HasRecipesAsync()
    {
        return await RecipeCards.CountAsync() > 0;
    }

    public async Task ClickRecipeAsync(int index = 0)
    {
        var card = RecipeCards.Nth(index);
        var cardLink = card.Locator("[data-testid='recipe-card-link']");
        await cardLink.ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task ClickRecipeByTitleAsync(string title)
    {
        var card = _page.Locator($"[data-testid='recipe-card']:has([data-testid='recipe-card-title']:has-text('{title}'))").First;
        await card.Locator("[data-testid='recipe-card-link']").ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task ToggleFavoriteAsync(int cardIndex = 0)
    {
        var card = RecipeCards.Nth(cardIndex);
        var favoriteButton = card.Locator("[data-testid='recipe-card-favorite']");
        // Use force click to bypass overlay interception
        await favoriteButton.ClickAsync(new LocatorClickOptions { Force = true });
        await _page.WaitForTimeoutAsync(300);
    }

    public async Task NavigateToNewRecipeAsync()
    {
        await NewRecipeButton.First.ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task<bool> IsSearchInputVisibleAsync()
    {
        return await SearchInput.IsVisibleAsync();
    }

    public async Task<string> GetPageTitleAsync()
    {
        return await _page.TitleAsync();
    }

    public async Task WaitForRecipesToLoadAsync()
    {
        await _page.WaitForSelectorAsync("[data-testid='recipe-card']",
            new PageWaitForSelectorOptions { Timeout = 10000 });
    }
}
