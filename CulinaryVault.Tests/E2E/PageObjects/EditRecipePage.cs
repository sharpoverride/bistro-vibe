using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E.PageObjects;

public class EditRecipePage
{
    private readonly IPage _page;

    public EditRecipePage(IPage page)
    {
        _page = page;
    }

    // Selectors using data-testid
    private ILocator TitleInput => _page.Locator("[data-testid='title-input']");
    private ILocator DescriptionInput => _page.Locator("[data-testid='description-input']");
    private ILocator ServingsInput => _page.Locator("[data-testid='servings-input'], input[type='number'][min='1'][max='100']").First;
    private ILocator SaveButton => _page.Locator("[data-testid='save-button']");
    private ILocator DeleteButton => _page.Locator("[data-testid='delete-button']");
    private ILocator DeleteDialog => _page.Locator("[data-testid='delete-dialog']");
    private ILocator DeleteConfirmButton => _page.Locator("[data-testid='delete-confirm-button']");
    private ILocator DeleteCancelButton => _page.Locator("[data-testid='delete-cancel-button']");

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
        await _page.WaitForTimeoutAsync(200);
    }

    public async Task ConfirmDeleteAsync()
    {
        await DeleteButton.ClickAsync();
        await DeleteConfirmButton.WaitForAsync();
        await DeleteConfirmButton.ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task CancelDeleteAsync()
    {
        await DeleteButton.ClickAsync();
        await DeleteCancelButton.WaitForAsync();
        await DeleteCancelButton.ClickAsync();
        await _page.WaitForTimeoutAsync(200);
    }

    public async Task<bool> IsFormVisibleAsync()
    {
        return await TitleInput.IsVisibleAsync();
    }

    public async Task<bool> IsDeleteDialogVisibleAsync()
    {
        return await DeleteDialog.IsVisibleAsync();
    }
}
