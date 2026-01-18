using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E.PageObjects;

public class EditRecipePage
{
    private readonly IPage _page;

    public EditRecipePage(IPage page)
    {
        _page = page;
    }

    // Selectors
    private ILocator TitleInput => _page.Locator("input[name='Title'], input[placeholder*='titlu'], #title").First;
    private ILocator DescriptionInput => _page.Locator("textarea[name='Description'], textarea[placeholder*='descriere'], #description").First;
    private ILocator ServingsInput => _page.Locator("input[name='Servings'], input[type='number'], #servings").First;
    private ILocator SaveButton => _page.Locator("button[type='submit'], button:has-text('Salvează')").First;
    private ILocator DeleteButton => _page.Locator("button:has-text('Șterge'), button:has-text('Delete')").First;
    private ILocator ConfirmDeleteButton => _page.Locator("[data-testid='confirm-delete'], button:has-text('Confirmă'), button:has-text('Da')").First;
    private ILocator CancelDeleteButton => _page.Locator("[data-testid='cancel-delete'], button:has-text('Anulează'), button:has-text('Nu')").First;

    public async Task NavigateAsync(Guid recipeId)
    {
        await _page.GotoAsync($"/recipes/{recipeId}/edit");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task<string> GetTitleValueAsync()
    {
        return await TitleInput.InputValueAsync();
    }

    public async Task<string> GetDescriptionValueAsync()
    {
        return await DescriptionInput.InputValueAsync();
    }

    public async Task UpdateTitleAsync(string newTitle)
    {
        await TitleInput.ClearAsync();
        await TitleInput.FillAsync(newTitle);
    }

    public async Task UpdateDescriptionAsync(string newDescription)
    {
        await DescriptionInput.ClearAsync();
        await DescriptionInput.FillAsync(newDescription);
    }

    public async Task UpdateServingsAsync(int servings)
    {
        await ServingsInput.ClearAsync();
        await ServingsInput.FillAsync(servings.ToString());
    }

    public async Task SaveAsync()
    {
        await SaveButton.ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task ClickDeleteAsync()
    {
        await DeleteButton.ClickAsync();
        await _page.WaitForTimeoutAsync(300);
    }

    public async Task ConfirmDeleteAsync()
    {
        await ConfirmDeleteButton.ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task CancelDeleteAsync()
    {
        await CancelDeleteButton.ClickAsync();
        await _page.WaitForTimeoutAsync(300);
    }

    public async Task<bool> IsFormVisibleAsync()
    {
        return await TitleInput.IsVisibleAsync();
    }

    public async Task<bool> IsDeleteConfirmationVisibleAsync()
    {
        return await ConfirmDeleteButton.IsVisibleAsync();
    }
}
