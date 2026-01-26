using CulinaryVault.Tests.E2E.Fixtures;
using CulinaryVault.Tests.E2E.PageObjects;

namespace CulinaryVault.Tests.E2E;

[Collection("Playwright")]
public class EditDeleteRecipeTests : IClassFixture<PlaywrightFixture>
{
    private readonly PlaywrightFixture _fixture;

    public EditDeleteRecipeTests(PlaywrightFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task EditRecipe_PageLoads_ShowsExistingData()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);
        var editPage = new EditRecipePage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);

        var originalTitle = await detailPage.GetTitleAsync();
        await detailPage.ClickEditAsync();

        // Act
        var editTitle = await editPage.GetTitleValueAsync();

        // Assert
        editTitle.Should().NotBeEmpty();
    }

    [Fact]
    public async Task EditRecipe_UpdateTitle_SavesSuccessfully()
    {
        // Arrange - First create a new recipe to edit
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);
        var detailPage = new RecipeDetailPage(page);
        var editPage = new EditRecipePage(page);

        var originalTitle = $"Original Title {Guid.NewGuid():N}";
        var updatedTitle = $"Updated Title {Guid.NewGuid():N}";

        await newRecipePage.NavigateAsync();
        await newRecipePage.FillBasicInfoAsync(originalTitle, "Description", 4);
        await newRecipePage.SubmitAsync();

        // Navigate to edit page
        await detailPage.ClickEditAsync();

        // Act
        await editPage.UpdateTitleAsync(updatedTitle);
        await editPage.SaveAsync();

        // Assert
        var newTitle = await detailPage.GetTitleAsync();
        newTitle.Should().Contain(updatedTitle);
    }

    [Fact]
    public async Task EditRecipe_UpdateDescription_SavesSuccessfully()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);
        var detailPage = new RecipeDetailPage(page);
        var editPage = new EditRecipePage(page);

        var title = $"Recipe for Description Edit {Guid.NewGuid():N}";
        var updatedDescription = $"Updated description {Guid.NewGuid():N}";

        await newRecipePage.NavigateAsync();
        await newRecipePage.FillBasicInfoAsync(title, "Original description", 4);
        await newRecipePage.SubmitAsync();

        await detailPage.ClickEditAsync();

        // Act
        await editPage.UpdateDescriptionAsync(updatedDescription);
        await editPage.SaveAsync();

        // Assert - should redirect to detail page without errors
        var url = page.Url;
        url.Should().Contain("/recipes/");
        url.Should().NotContain("/edit");
    }

    [Fact]
    public async Task DeleteRecipe_ShowsConfirmationDialog()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);
        var editPage = new EditRecipePage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);
        await detailPage.ClickEditAsync();

        // Act
        await editPage.ClickDeleteAsync();

        // Assert
        var isVisible = await editPage.IsDeleteDialogVisibleAsync();
        isVisible.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteRecipe_CancelDelete_StaysOnEditPage()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var homePage = new HomePage(page);
        var detailPage = new RecipeDetailPage(page);
        var editPage = new EditRecipePage(page);

        await homePage.NavigateAsync();
        await homePage.WaitForRecipesToLoadAsync();
        await homePage.ClickRecipeAsync(0);
        await detailPage.ClickEditAsync();

        // Act - Open dialog and cancel
        await editPage.CancelDeleteAsync();

        // Assert
        var isFormVisible = await editPage.IsFormVisibleAsync();
        isFormVisible.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteRecipe_ConfirmDelete_RemovesRecipe()
    {
        // Arrange - Create a recipe to delete
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);
        var detailPage = new RecipeDetailPage(page);
        var editPage = new EditRecipePage(page);
        var homePage = new HomePage(page);

        var uniqueTitle = $"Recipe To Delete {Guid.NewGuid():N}";

        await newRecipePage.NavigateAsync();
        await newRecipePage.FillBasicInfoAsync(uniqueTitle, "Description", 4);
        await newRecipePage.SubmitAsync();

        await detailPage.ClickEditAsync();

        // Act - Open dialog and confirm delete
        await editPage.ConfirmDeleteAsync();

        // Assert - Should redirect to home page
        var url = page.Url;
        url.Should().EndWith("/");

        // Recipe should not be found in search
        await homePage.SearchAsync(uniqueTitle);
        var count = await homePage.GetRecipeCountAsync();
        count.Should().Be(0);
    }
}
