using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E.PageObjects;

public class RecipeDetailPage
{
    private readonly IPage _page;

    public RecipeDetailPage(IPage page)
    {
        _page = page;
    }

    // Selectors
    private ILocator Title => _page.Locator("h1").First;
    private ILocator Description => _page.Locator("[data-testid='recipe-description'], .description, p").First;
    private ILocator FavoriteButton => _page.Locator("button:has(svg[data-lucide='heart']), button:has(.lucide-heart)").First;
    private ILocator EditButton => _page.Locator("a[href*='/edit'], button:has-text('Editează')").First;
    private ILocator IngredientsList => _page.Locator("[data-testid='ingredients'], .ingredients, ul").First;
    private ILocator InstructionsList => _page.Locator("[data-testid='instructions'], .instructions, ol").First;
    private ILocator ServingsDisplay => _page.Locator("[data-testid='servings'], .servings");
    private ILocator IncreaseServingsButton => _page.Locator("button:has-text('+')").First;
    private ILocator DecreaseServingsButton => _page.Locator("button:has-text('-')").First;
    private ILocator FocusModeButton => _page.Locator("button:has-text('Mod Focus'), button:has-text('Focus')").First;

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
        var button = FavoriteButton;
        var svg = button.Locator("svg").First;
        var fill = await svg.GetAttributeAsync("fill");
        return fill != "none" && !string.IsNullOrEmpty(fill);
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
            await DecreaseServingsButton.ClickAsync();
            await _page.WaitForTimeoutAsync(100);
        }
    }

    public async Task<int> GetCurrentServingsAsync()
    {
        var text = await ServingsDisplay.TextContentAsync() ?? "0";
        // Extract number from text like "4 porții" or just "4"
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
