using CulinaryVault.Tests.E2E.Fixtures;
using CulinaryVault.Tests.E2E.PageObjects;

namespace CulinaryVault.Tests.E2E;

[Collection("Playwright")]
public class CreateRecipeTests : IClassFixture<PlaywrightFixture>
{
    private readonly PlaywrightFixture _fixture;

    public CreateRecipeTests(PlaywrightFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(Skip = "Requires running application")]
    public async Task NewRecipe_PageLoads_ShowsForm()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);

        // Act
        await newRecipePage.NavigateAsync();

        // Assert
        var isVisible = await newRecipePage.IsFormVisibleAsync();
        isVisible.Should().BeTrue();
    }

    [Fact(Skip = "Requires running application")]
    public async Task NewRecipe_CreateWithBasicInfo_Succeeds()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);
        var uniqueTitle = $"Test Recipe {Guid.NewGuid():N}";

        await newRecipePage.NavigateAsync();

        // Act
        await newRecipePage.FillBasicInfoAsync(uniqueTitle, "Test description", 4);
        await newRecipePage.SubmitAsync();

        // Assert
        var url = page.Url;
        url.Should().Contain("/recipes/");
        url.Should().NotContain("/new");
    }

    [Fact(Skip = "Requires running application")]
    public async Task NewRecipe_CreateWithIngredients_Succeeds()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);
        var uniqueTitle = $"Recipe With Ingredients {Guid.NewGuid():N}";

        await newRecipePage.NavigateAsync();

        // Act
        await newRecipePage.FillBasicInfoAsync(uniqueTitle, "Description", 4);
        await newRecipePage.AddIngredientAsync("Flour", 200, "g");
        await newRecipePage.AddIngredientAsync("Sugar", 100, "g");
        await newRecipePage.SubmitAsync();

        // Assert
        var url = page.Url;
        url.Should().Contain("/recipes/");
    }

    [Fact(Skip = "Requires running application")]
    public async Task NewRecipe_CreateWithInstructions_Succeeds()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);
        var uniqueTitle = $"Recipe With Instructions {Guid.NewGuid():N}";

        await newRecipePage.NavigateAsync();

        // Act
        await newRecipePage.FillBasicInfoAsync(uniqueTitle, "Description", 4);
        await newRecipePage.AddInstructionAsync("Mix all ingredients");
        await newRecipePage.AddInstructionAsync("Bake at 180°C");
        await newRecipePage.SubmitAsync();

        // Assert
        var url = page.Url;
        url.Should().Contain("/recipes/");
    }

    [Fact(Skip = "Requires running application")]
    public async Task NewRecipe_CreateFullRecipe_DisplaysCorrectly()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);
        var detailPage = new RecipeDetailPage(page);
        var uniqueTitle = $"Full Recipe {Guid.NewGuid():N}";

        await newRecipePage.NavigateAsync();

        // Act
        await newRecipePage.CreateFullRecipeAsync(
            title: uniqueTitle,
            description: "A complete test recipe",
            cuisineType: "Test",
            servings: 6,
            ingredients: new()
            {
                ("Flour", 200, "g"),
                ("Sugar", 100, "g"),
                ("Eggs", 2, "pcs")
            },
            instructions: new()
            {
                "Mix dry ingredients",
                "Add eggs and mix well",
                "Bake at 180°C for 30 minutes"
            }
        );

        // Assert - Should redirect to detail page
        var title = await detailPage.GetTitleAsync();
        title.Should().Contain(uniqueTitle);
    }

    [Fact(Skip = "Requires running application")]
    public async Task NewRecipe_CanSetPrepAndCookTime()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);
        var uniqueTitle = $"Timed Recipe {Guid.NewGuid():N}";

        await newRecipePage.NavigateAsync();

        // Act
        await newRecipePage.FillBasicInfoAsync(uniqueTitle, "Description", 4);
        await newRecipePage.SetPrepTimeAsync(15);
        await newRecipePage.SetCookTimeAsync(30);
        await newRecipePage.SubmitAsync();

        // Assert
        var url = page.Url;
        url.Should().Contain("/recipes/");
    }

    [Fact(Skip = "Requires running application")]
    public async Task NewRecipe_CanSetCuisineType()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);
        var uniqueTitle = $"Italian Recipe {Guid.NewGuid():N}";

        await newRecipePage.NavigateAsync();

        // Act
        await newRecipePage.FillBasicInfoAsync(uniqueTitle, "Description", 4);
        await newRecipePage.SetCuisineTypeAsync("Italian");
        await newRecipePage.SubmitAsync();

        // Assert
        var url = page.Url;
        url.Should().Contain("/recipes/");
    }
}
