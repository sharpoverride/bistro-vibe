using System;
using System.Collections.Generic;

namespace CulinaryVault.Shared
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;              // Required
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public TimeSpan PrepTime { get; set; }
        public TimeSpan CookTime { get; set; }
        public int Servings { get; set; } = 4;              // Range: 1-100, Default: 4
        public Difficulty Difficulty { get; set; }      // Enum: Easy, Medium, Hard, Expert
        public string CuisineType { get; set; } = "General";        // Default: "General"
        public bool IsFavorite { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();    // Stored as JSON
        public List<Instruction> Instructions { get; set; } = new List<Instruction>();  // Stored as JSON
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard,
        Expert
    }
}
