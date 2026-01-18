using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CulinaryVault.Shared
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetRecipesAsync();
        Task<Recipe?> GetRecipeByIdAsync(Guid id);
        Task<Recipe> CreateRecipeAsync(Recipe recipe);
        Task<Recipe> UpdateRecipeAsync(Recipe recipe);
        Task DeleteRecipeAsync(Guid id);
        Task<List<Recipe>> SearchRecipesAsync(string searchTerm);
        Task<Recipe> ToggleFavoriteAsync(Guid id);
        Task<List<Recipe>> GetFavoritesAsync();
        Task<List<string>> GetCuisineTypesAsync();
        Task<List<Recipe>> GetRecipesByCuisineAsync(string cuisineType);
    }
}
