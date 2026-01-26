using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E.PageObjects;

public class NewRecipePage
{
    private readonly IPage _page;

    public NewRecipePage(IPage page)
    {
        _page = page;
    }

    // Selectors using data-testid
    private ILocator TitleInput => _page.Locator("[data-testid='title-input']");
    private ILocator DescriptionInput => _page.Locator("[data-testid='description-input']");
    private ILocator ImageUrlInput => _page.Locator("[data-testid='image-url-input']");
    private ILocator PrepTimeInput => _page.Locator("[data-testid='prep-time-input']");
    private ILocator CookTimeInput => _page.Locator("[data-testid='cook-time-input']");
    private ILocator ServingsInput => _page.Locator("[data-testid='servings-input']");
    private ILocator CuisineTypeInput => _page.Locator("[data-testid='cuisine-type-input']");
    private ILocator DifficultySelect => _page.Locator("[data-testid='difficulty-select']");
    private ILocator AddIngredientButton => _page.Locator("[data-testid='add-ingredient-button']");
    private ILocator AddInstructionButton => _page.Locator("[data-testid='add-instruction-button']");
    private ILocator SubmitButton => _page.Locator("[data-testid='submit-button']");
    private ILocator IngredientRows => _page.Locator("[data-testid='ingredient-row']");
    private ILocator InstructionRows => _page.Locator("[data-testid='instruction-row']");

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
        await ServingsInput.ClearAsync();
        await ServingsInput.FillAsync(servings.ToString());
    }

    public async Task SetPrepTimeAsync(int minutes)
    {
        await PrepTimeInput.ClearAsync();
        await PrepTimeInput.FillAsync(minutes.ToString());
    }

    public async Task SetCookTimeAsync(int minutes)
    {
        await CookTimeInput.ClearAsync();
        await CookTimeInput.FillAsync(minutes.ToString());
    }

    public async Task SetCuisineTypeAsync(string cuisineType)
    {
        await CuisineTypeInput.ClearAsync();
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
        var lastRow = IngredientRows.Last;
        await lastRow.Locator("[data-testid='ingredient-amount']").FillAsync(amount.ToString());
        await lastRow.Locator("[data-testid='ingredient-unit']").FillAsync(unit);
        await lastRow.Locator("[data-testid='ingredient-name']").FillAsync(name);
    }

    public async Task AddInstructionAsync(string text)
    {
        await AddInstructionButton.ClickAsync();
        await _page.WaitForTimeoutAsync(200);

        // Get the last instruction row
        var lastRow = InstructionRows.Last;
        await lastRow.Locator("[data-testid='instruction-text']").FillAsync(text);
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

    public async Task<int> GetIngredientCountAsync()
    {
        return await IngredientRows.CountAsync();
    }

    public async Task<int> GetInstructionCountAsync()
    {
        return await InstructionRows.CountAsync();
    }

    public async Task<string> GetIngredientNameAtAsync(int index)
    {
        var row = IngredientRows.Nth(index);
        return await row.Locator("[data-testid='ingredient-name']").InputValueAsync();
    }

    public async Task<string> GetInstructionTextAtAsync(int index)
    {
        var row = InstructionRows.Nth(index);
        return await row.Locator("[data-testid='instruction-text']").InputValueAsync();
    }

    public async Task DragIngredientAsync(int fromIndex, int toIndex)
    {
        var fromRow = IngredientRows.Nth(fromIndex);
        var toRow = IngredientRows.Nth(toIndex);

        var fromHandle = fromRow.Locator("[data-testid='ingredient-drag-handle']");
        var toHandle = toRow.Locator("[data-testid='ingredient-drag-handle']");

        await fromHandle.DragToAsync(toHandle);
        await _page.WaitForTimeoutAsync(200);
    }

    public async Task DragInstructionAsync(int fromIndex, int toIndex)
    {
        var fromRow = InstructionRows.Nth(fromIndex);
        var toRow = InstructionRows.Nth(toIndex);

        var fromHandle = fromRow.Locator("[data-testid='instruction-drag-handle']");
        var toHandle = toRow.Locator("[data-testid='instruction-drag-handle']");

        await fromHandle.DragToAsync(toHandle);
        await _page.WaitForTimeoutAsync(200);
    }

    public async Task RemoveIngredientAtAsync(int index)
    {
        var row = IngredientRows.Nth(index);
        await row.Locator("[data-testid='ingredient-delete']").ClickAsync();
        await _page.WaitForTimeoutAsync(200);
    }

    public async Task RemoveInstructionAtAsync(int index)
    {
        var row = InstructionRows.Nth(index);
        await row.Locator("[data-testid='instruction-delete']").ClickAsync();
        await _page.WaitForTimeoutAsync(200);
    }
}
