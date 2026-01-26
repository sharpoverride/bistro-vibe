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

    [Fact()]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
    public async Task NewRecipe_CanDragReorderIngredients()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);

        await newRecipePage.NavigateAsync();

        // Add three ingredients
        await newRecipePage.AddIngredientAsync("First Ingredient", 1, "cup");
        await newRecipePage.AddIngredientAsync("Second Ingredient", 2, "tbsp");
        await newRecipePage.AddIngredientAsync("Third Ingredient", 3, "g");

        // Verify initial order
        var firstBefore = await newRecipePage.GetIngredientNameAtAsync(0);
        firstBefore.Should().Be("First Ingredient");

        // Act - Drag first ingredient to third position
        await newRecipePage.DragIngredientAsync(0, 2);

        // Assert - First ingredient should now be at position 2
        var firstAfter = await newRecipePage.GetIngredientNameAtAsync(0);
        firstAfter.Should().Be("Second Ingredient");
    }

    [Fact]
    public async Task NewRecipe_CanDragReorderInstructions()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);

        await newRecipePage.NavigateAsync();

        // Add three instructions
        await newRecipePage.AddInstructionAsync("Step One");
        await newRecipePage.AddInstructionAsync("Step Two");
        await newRecipePage.AddInstructionAsync("Step Three");

        // Verify initial order
        var firstBefore = await newRecipePage.GetInstructionTextAtAsync(0);
        firstBefore.Should().Be("Step One");

        // Act - Drag first instruction to third position
        await newRecipePage.DragInstructionAsync(0, 2);

        // Assert - First instruction should now be at position 2
        var firstAfter = await newRecipePage.GetInstructionTextAtAsync(0);
        firstAfter.Should().Be("Step Two");
    }

    [Fact]
    public async Task NewRecipe_CanRemoveIngredient()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);

        await newRecipePage.NavigateAsync();

        // Add two ingredients
        await newRecipePage.AddIngredientAsync("Keep Me", 1, "cup");
        await newRecipePage.AddIngredientAsync("Delete Me", 2, "tbsp");

        var countBefore = await newRecipePage.GetIngredientCountAsync();
        countBefore.Should().Be(2);

        // Act - Remove the second ingredient
        await newRecipePage.RemoveIngredientAtAsync(1);

        // Assert
        var countAfter = await newRecipePage.GetIngredientCountAsync();
        countAfter.Should().Be(1);

        var remainingName = await newRecipePage.GetIngredientNameAtAsync(0);
        remainingName.Should().Be("Keep Me");
    }

    [Fact]
    public async Task NewRecipe_CanRemoveInstruction()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);

        await newRecipePage.NavigateAsync();

        // Add two instructions
        await newRecipePage.AddInstructionAsync("Keep This Step");
        await newRecipePage.AddInstructionAsync("Delete This Step");

        var countBefore = await newRecipePage.GetInstructionCountAsync();
        countBefore.Should().Be(2);

        // Act - Remove the second instruction
        await newRecipePage.RemoveInstructionAtAsync(1);

        // Assert
        var countAfter = await newRecipePage.GetInstructionCountAsync();
        countAfter.Should().Be(1);

        var remainingText = await newRecipePage.GetInstructionTextAtAsync(0);
        remainingText.Should().Be("Keep This Step");
    }

    [Fact]
    public async Task NewRecipe_ReorderedIngredients_PersistAfterSave()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var newRecipePage = new NewRecipePage(page);
        var detailPage = new RecipeDetailPage(page);
        var uniqueTitle = $"Reorder Recipe {Guid.NewGuid():N}";

        await newRecipePage.NavigateAsync();
        await newRecipePage.FillBasicInfoAsync(uniqueTitle, "Description", 4);

        // Add three ingredients
        await newRecipePage.AddIngredientAsync("Alpha", 1, "cup");
        await newRecipePage.AddIngredientAsync("Beta", 2, "tbsp");
        await newRecipePage.AddIngredientAsync("Gamma", 3, "g");

        // Reorder: move first to last
        await newRecipePage.DragIngredientAsync(0, 2);

        // Act - Save the recipe
        await newRecipePage.SubmitAsync();

        // Assert - Should redirect to detail page
        var url = page.Url;
        url.Should().Contain("/recipes/");
        url.Should().NotContain("/new");
    }
}
