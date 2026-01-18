using CulinaryVault.Data;
using CulinaryVault.Shared;
using Microsoft.EntityFrameworkCore;

namespace CulinaryVault.Services;

public class RecipeService : IRecipeService
{
    private readonly CulinaryVaultDbContext _db;

    public RecipeService(CulinaryVaultDbContext db) => _db = db;

    public async Task<List<Recipe>> GetRecipesAsync()
        => await _db.Recipes.AsNoTracking().OrderBy(r => r.Title).ToListAsync();

    public async Task<Recipe?> GetRecipeByIdAsync(Guid id)
        => await _db.Recipes.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);

    public async Task<Recipe> CreateRecipeAsync(Recipe recipe)
    {
        recipe.Id = Guid.NewGuid();
        
        // Ensure all ingredients and instructions have IDs
        foreach (var ingredient in recipe.Ingredients)
        {
            if (ingredient.Id == Guid.Empty)
                ingredient.Id = Guid.NewGuid();
        }
        foreach (var instruction in recipe.Instructions)
        {
            if (instruction.Id == Guid.Empty)
                instruction.Id = Guid.NewGuid();
        }
        
        _db.Recipes.Add(recipe);
        await _db.SaveChangesAsync();
        return recipe;
    }

    public async Task<Recipe> UpdateRecipeAsync(Recipe recipe)
    {
        var existing = await _db.Recipes.FindAsync(recipe.Id);
        if (existing == null)
            throw new KeyNotFoundException($"Rețeta cu ID-ul {recipe.Id} nu a fost găsită.");

        existing.Title = recipe.Title;
        existing.Description = recipe.Description;
        existing.ImageUrl = recipe.ImageUrl;
        existing.PrepTime = recipe.PrepTime;
        existing.CookTime = recipe.CookTime;
        existing.Servings = recipe.Servings;
        existing.Difficulty = recipe.Difficulty;
        existing.CuisineType = recipe.CuisineType;
        existing.IsFavorite = recipe.IsFavorite;
        existing.Ingredients = recipe.Ingredients;
        existing.Instructions = recipe.Instructions;

        await _db.SaveChangesAsync();
        return existing;
    }

    public async Task DeleteRecipeAsync(Guid id)
    {
        var existing = await _db.Recipes.FindAsync(id);
        if (existing is null) return;
        _db.Recipes.Remove(existing);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Recipe>> SearchRecipesAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetRecipesAsync();

        searchTerm = searchTerm.ToLowerInvariant();

        // Note: Searching within JSON columns (Ingredients) requires client-side evaluation
        // For now, search Title, Description, and CuisineType server-side
        var recipes = await _db.Recipes
            .AsNoTracking()
            .Where(r =>
                EF.Functions.Like(r.Title.ToLower(), $"%{searchTerm}%") ||
                EF.Functions.Like(r.Description.ToLower(), $"%{searchTerm}%") ||
                EF.Functions.Like(r.CuisineType.ToLower(), $"%{searchTerm}%"))
            .OrderBy(r => r.Title)
            .ToListAsync();

        // Also search ingredients client-side
        var allRecipes = await _db.Recipes.AsNoTracking().ToListAsync();
        var ingredientMatches = allRecipes
            .Where(r => r.Ingredients.Any(i => i.Name.ToLower().Contains(searchTerm)))
            .ToList();

        // Combine results without duplicates
        return recipes.UnionBy(ingredientMatches, r => r.Id).OrderBy(r => r.Title).ToList();
    }

    public async Task<Recipe> ToggleFavoriteAsync(Guid id)
    {
        var recipe = await _db.Recipes.FindAsync(id)
                     ?? throw new KeyNotFoundException("Rețetă negăsită.");
        recipe.IsFavorite = !recipe.IsFavorite;
        await _db.SaveChangesAsync();
        return recipe;
    }

    public async Task<List<Recipe>> GetFavoritesAsync()
        => await _db.Recipes.AsNoTracking()
            .Where(r => r.IsFavorite)
            .OrderBy(r => r.Title)
            .ToListAsync();

    public async Task<List<string>> GetCuisineTypesAsync()
        => await _db.Recipes.AsNoTracking()
            .Select(r => r.CuisineType)
            .Distinct()
            .OrderBy(x => x)
            .ToListAsync();

    public async Task<List<Recipe>> GetRecipesByCuisineAsync(string cuisineType)
        => await _db.Recipes.AsNoTracking()
            .Where(r => r.CuisineType == cuisineType)
            .OrderBy(r => r.Title)
            .ToListAsync();
}
