using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E.PageObjects;

public class HomePage
{
    private readonly IPage _page;

    public HomePage(IPage page)
    {
        _page = page;
    }

    // Selectors
    private ILocator SearchInput => _page.Locator("input[placeholder*='Caută']");
    private ILocator RecipeCards => _page.Locator("[data-testid='recipe-card'], .recipe-card, article");
    private ILocator FavoriteButtons => _page.Locator("button:has(svg[data-lucide='heart']), button:has(.lucide-heart)");
    private ILocator NewRecipeButton => _page.Locator("a[href='/recipes/new'], button:has-text('Adaugă')");

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
        var cards = RecipeCards;
        await cards.Nth(index).ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task ClickRecipeByTitleAsync(string title)
    {
        var card = _page.Locator($"text={title}").First;
        await card.ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task ToggleFavoriteAsync(int cardIndex = 0)
    {
        var card = RecipeCards.Nth(cardIndex);
        var favoriteButton = card.Locator("button").First;
        await favoriteButton.ClickAsync();
        await _page.WaitForTimeoutAsync(300);
    }

    public async Task NavigateToNewRecipeAsync()
    {
        await NewRecipeButton.ClickAsync();
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
        await _page.WaitForSelectorAsync("[data-testid='recipe-card'], .recipe-card, article",
            new PageWaitForSelectorOptions { Timeout = 10000 });
    }
}
