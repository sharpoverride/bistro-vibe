using CulinaryVault.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryVault.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipesController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Recipe>>> GetRecipes()
    {
        var recipes = await _recipeService.GetRecipesAsync();
        return Ok(recipes);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Recipe>> GetRecipe(Guid id)
    {
        var recipe = await _recipeService.GetRecipeByIdAsync(id);
        if (recipe == null)
            return NotFound();
        return Ok(recipe);
    }

    [HttpPost]
    public async Task<ActionResult<Recipe>> CreateRecipe(Recipe recipe)
    {
        var created = await _recipeService.CreateRecipeAsync(recipe);
        return CreatedAtAction(nameof(GetRecipe), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Recipe>> UpdateRecipe(Guid id, Recipe recipe)
    {
        if (id != recipe.Id)
            return BadRequest("ID mismatch");

        try
        {
            var updated = await _recipeService.UpdateRecipeAsync(recipe);
            return Ok(updated);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteRecipe(Guid id)
    {
        await _recipeService.DeleteRecipeAsync(id);
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<Recipe>>> SearchRecipes([FromQuery] string term)
    {
        var recipes = await _recipeService.SearchRecipesAsync(term ?? "");
        return Ok(recipes);
    }

    [HttpPost("{id:guid}/favorite")]
    public async Task<ActionResult<Recipe>> ToggleFavorite(Guid id)
    {
        try
        {
            var recipe = await _recipeService.ToggleFavoriteAsync(id);
            return Ok(recipe);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("favorites")]
    public async Task<ActionResult<List<Recipe>>> GetFavorites()
    {
        var recipes = await _recipeService.GetFavoritesAsync();
        return Ok(recipes);
    }

    [HttpGet("cuisine-types")]
    public async Task<ActionResult<List<string>>> GetCuisineTypes()
    {
        var cuisineTypes = await _recipeService.GetCuisineTypesAsync();
        return Ok(cuisineTypes);
    }

    [HttpGet("cuisine/{cuisineType}")]
    public async Task<ActionResult<List<Recipe>>> GetRecipesByCuisine(string cuisineType)
    {
        var recipes = await _recipeService.GetRecipesByCuisineAsync(cuisineType);
        return Ok(recipes);
    }
}
