using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E.PageObjects;

public class NewRecipePage
{
    private readonly IPage _page;

    public NewRecipePage(IPage page)
    {
        _page = page;
    }

    // Selectors
    private ILocator TitleInput => _page.Locator("input[name='Title'], input[placeholder*='titlu'], #title").First;
    private ILocator DescriptionInput => _page.Locator("textarea[name='Description'], textarea[placeholder*='descriere'], #description").First;
    private ILocator ImageUrlInput => _page.Locator("input[name='ImageUrl'], input[placeholder*='imagine'], #imageUrl").First;
    private ILocator PrepTimeInput => _page.Locator("input[name='PrepTime'], input[placeholder*='preparare'], #prepTime").First;
    private ILocator CookTimeInput => _page.Locator("input[name='CookTime'], input[placeholder*='gătire'], #cookTime").First;
    private ILocator ServingsInput => _page.Locator("input[name='Servings'], input[type='number'], #servings").First;
    private ILocator CuisineTypeInput => _page.Locator("input[name='CuisineType'], input[placeholder*='bucătărie'], #cuisineType").First;
    private ILocator DifficultySelect => _page.Locator("select[name='Difficulty'], #difficulty").First;
    private ILocator AddIngredientButton => _page.Locator("button:has-text('Adaugă ingredient'), button:has-text('+ Ingredient')").First;
    private ILocator AddInstructionButton => _page.Locator("button:has-text('Adaugă pas'), button:has-text('+ Pas')").First;
    private ILocator SubmitButton => _page.Locator("button[type='submit'], button:has-text('Salvează'), button:has-text('Creează')").First;

    public async Task NavigateAsync()
    {
        await _page.GotoAsync("/recipes/new");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task FillBasicInfoAsync(string title, string description = "", int servings = 4)
    {
        await TitleInput.FillAsync(title);
        if (!string.IsNullOrEmpty(description))
        {
            await DescriptionInput.FillAsync(description);
        }
        await ServingsInput.FillAsync(servings.ToString());
    }

    public async Task SetPrepTimeAsync(int minutes)
    {
        await PrepTimeInput.FillAsync(minutes.ToString());
    }

    public async Task SetCookTimeAsync(int minutes)
    {
        await CookTimeInput.FillAsync(minutes.ToString());
    }

    public async Task SetCuisineTypeAsync(string cuisineType)
    {
        await CuisineTypeInput.FillAsync(cuisineType);
    }

    public async Task SetDifficultyAsync(string difficulty)
    {
        await DifficultySelect.SelectOptionAsync(difficulty);
    }

    public async Task SetImageUrlAsync(string url)
    {
        await ImageUrlInput.FillAsync(url);
    }

    public async Task AddIngredientAsync(string name, double amount, string unit)
    {
        await AddIngredientButton.ClickAsync();
        await _page.WaitForTimeoutAsync(200);

        // Get the last ingredient row
        var ingredientRows = _page.Locator("[data-testid='ingredient-row'], .ingredient-row, .ingredient").Last;
        await ingredientRows.Locator("input[name*='Name'], input[placeholder*='nume']").First.FillAsync(name);
        await ingredientRows.Locator("input[name*='Amount'], input[type='number']").First.FillAsync(amount.ToString());
        await ingredientRows.Locator("input[name*='Unit'], input[placeholder*='unitate']").First.FillAsync(unit);
    }

    public async Task AddInstructionAsync(string text)
    {
        await AddInstructionButton.ClickAsync();
        await _page.WaitForTimeoutAsync(200);

        // Get the last instruction row
        var instructionRows = _page.Locator("[data-testid='instruction-row'], .instruction-row, .instruction").Last;
        await instructionRows.Locator("textarea, input[type='text']").First.FillAsync(text);
    }

    public async Task SubmitAsync()
    {
        await SubmitButton.ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task<bool> IsFormVisibleAsync()
    {
        return await TitleInput.IsVisibleAsync();
    }

    public async Task CreateFullRecipeAsync(
        string title,
        string description,
        string cuisineType,
        int servings,
        List<(string name, double amount, string unit)> ingredients,
        List<string> instructions)
    {
        await FillBasicInfoAsync(title, description, servings);
        await SetCuisineTypeAsync(cuisineType);

        foreach (var ingredient in ingredients)
        {
            await AddIngredientAsync(ingredient.name, ingredient.amount, ingredient.unit);
        }

        foreach (var instruction in instructions)
        {
            await AddInstructionAsync(instruction);
        }

        await SubmitAsync();
    }
}
