using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E.PageObjects;

public class RecipeDetailPage
{
    private readonly IPage _page;

    public RecipeDetailPage(IPage page)
    {
        _page = page;
    }

    // Selectors using data-testid
    private ILocator Title => _page.Locator("[data-testid='recipe-title']");
    private ILocator Description => _page.Locator("[data-testid='recipe-description']");
    private ILocator FavoriteButton => _page.Locator("[data-testid='favorite-button']");
    private ILocator EditButton => _page.Locator("[data-testid='edit-button']");
    private ILocator IngredientsList => _page.Locator("[data-testid='ingredients-list']");
    private ILocator InstructionsList => _page.Locator("[data-testid='instructions-list']");
    private ILocator ServingsSection => _page.Locator("[data-testid='servings-section']");
    private ILocator ServingsCount => _page.Locator("[data-testid='servings-count']");
    private ILocator IncreaseServingsButton => _page.Locator("[data-testid='increase-servings']");
    private ILocator DecreaseServingsButton => _page.Locator("[data-testid='decrease-servings']");
    private ILocator FocusModeButton => _page.Locator("[data-testid='focus-mode-button']");

    public async Task NavigateAsync(Guid recipeId)
    {
        await _page.GotoAsync($"/recipes/{recipeId}");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task<string> GetTitleAsync()
    {
        await Title.WaitForAsync();
        return await Title.TextContentAsync() ?? "";
    }

    public async Task<string> GetDescriptionAsync()
    {
        return await Description.TextContentAsync() ?? "";
    }

    public async Task ToggleFavoriteAsync()
    {
        await FavoriteButton.ClickAsync();
        await _page.WaitForTimeoutAsync(300);
    }

    public async Task<bool> IsFavoriteAsync()
    {
        var svg = FavoriteButton.Locator("svg").First;
        var fill = await svg.GetAttributeAsync("fill");
        return fill == "currentColor";
    }

    public async Task ClickEditAsync()
    {
        await EditButton.ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task<int> GetIngredientCountAsync()
    {
        var items = IngredientsList.Locator("li");
        return await items.CountAsync();
    }

    public async Task<int> GetInstructionCountAsync()
    {
        var items = InstructionsList.Locator("li");
        return await items.CountAsync();
    }

    public async Task IncreaseServingsAsync(int times = 1)
    {
        for (int i = 0; i < times; i++)
        {
            await IncreaseServingsButton.ClickAsync();
            await _page.WaitForTimeoutAsync(100);
        }
    }

    public async Task DecreaseServingsAsync(int times = 1)
    {
        for (int i = 0; i < times; i++)
        {
            // Check if button is enabled before clicking
            var isEnabled = await DecreaseServingsButton.IsEnabledAsync();
            if (!isEnabled) break;
            await DecreaseServingsButton.ClickAsync();
            await _page.WaitForTimeoutAsync(100);
        }
    }

    public async Task<int> GetCurrentServingsAsync()
    {
        var text = await ServingsCount.TextContentAsync() ?? "0";
        var match = System.Text.RegularExpressions.Regex.Match(text, @"\d+");
        return match.Success ? int.Parse(match.Value) : 0;
    }

    public async Task OpenFocusModeAsync()
    {
        await FocusModeButton.ClickAsync();
        await _page.WaitForTimeoutAsync(300);
    }

    public async Task<bool> IsLoadedAsync()
    {
        return await Title.IsVisibleAsync();
    }
}
