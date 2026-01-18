using System.Text.Json;
using CulinaryVault.Shared;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("🍳 Culinary Vault - Recipe Importer");
Console.WriteLine("===================================\n");

if (args.Length == 0)
{
    ShowHelp();
    return;
}

var command = args[0].ToLower();

switch (command)
{
    case "import":
        if (args.Length < 2)
        {
            Console.WriteLine("Error: Please specify a JSON file to import");
            Console.WriteLine("Usage: RecipeImporter import <file.json> [--db <path>]");
            return;
        }
        await ImportRecipes(args);
        break;
        
    case "list":
        await ListRecipes(args);
        break;
        
    case "export":
        if (args.Length < 2)
        {
            Console.WriteLine("Error: Please specify an output file");
            Console.WriteLine("Usage: RecipeImporter export <output.json> [--db <path>]");
            return;
        }
        await ExportRecipes(args);
        break;
        
    case "help":
    default:
        ShowHelp();
        break;
}

void ShowHelp()
{
    Console.WriteLine("Commands:");
    Console.WriteLine("  import <file.json> [--db <path>]  Import recipes from JSON file");
    Console.WriteLine("  export <output.json> [--db <path>] Export all recipes to JSON file");
    Console.WriteLine("  list [--db <path>]                List all recipes in database");
    Console.WriteLine("  help                              Show this help message");
    Console.WriteLine();
    Console.WriteLine("Options:");
    Console.WriteLine("  --db <path>  Path to SQLite database (default: data/culinaryvault.db)");
    Console.WriteLine();
    Console.WriteLine("Example JSON format for import:");
    Console.WriteLine(@"{
  ""recipes"": [
    {
      ""title"": ""Recipe Name"",
      ""description"": ""Description"",
      ""prepTimeMinutes"": 30,
      ""cookTimeMinutes"": 45,
      ""servings"": 4,
      ""difficulty"": ""Medium"",
      ""cuisineType"": ""Romanian"",
      ""ingredients"": [
        { ""name"": ""Ingredient"", ""amount"": 100, ""unit"": ""g"" }
      ],
      ""instructions"": [
        ""Step 1 description"",
        ""Step 2 description""
      ]
    }
  ]
}");
}

async Task ImportRecipes(string[] args)
{
    var jsonFile = args[1];
    var dbPath = GetDbPath(args);
    
    if (!File.Exists(jsonFile))
    {
        Console.WriteLine($"Error: File not found: {jsonFile}");
        return;
    }
    
    Console.WriteLine($"Importing from: {jsonFile}");
    Console.WriteLine($"Database: {dbPath}");
    
    try
    {
        var json = await File.ReadAllTextAsync(jsonFile);
        var importData = JsonSerializer.Deserialize<ImportData>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        
        if (importData?.Recipes == null || importData.Recipes.Count == 0)
        {
            Console.WriteLine("No recipes found in file");
            return;
        }
        
        await using var db = CreateDbContext(dbPath);
        await db.Database.EnsureCreatedAsync();
        
        var count = 0;
        foreach (var importRecipe in importData.Recipes)
        {
            var recipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Title = importRecipe.Title ?? "Untitled",
                Description = importRecipe.Description ?? "",
                ImageUrl = importRecipe.ImageUrl ?? "",
                PrepTime = TimeSpan.FromMinutes(importRecipe.PrepTimeMinutes),
                CookTime = TimeSpan.FromMinutes(importRecipe.CookTimeMinutes),
                Servings = importRecipe.Servings > 0 ? importRecipe.Servings : 4,
                Difficulty = Enum.TryParse<Difficulty>(importRecipe.Difficulty, true, out var diff) ? diff : Difficulty.Medium,
                CuisineType = importRecipe.CuisineType ?? "General",
                IsFavorite = importRecipe.IsFavorite,
                Ingredients = importRecipe.Ingredients?.Select((ing, index) => new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Name = ing.Name ?? "",
                    Amount = ing.Amount,
                    Unit = ing.Unit ?? "",
                    Order = index + 1
                }).ToList() ?? new List<Ingredient>(),
                Instructions = importRecipe.Instructions?.Select((text, index) => new Instruction
                {
                    Id = Guid.NewGuid(),
                    StepNumber = index + 1,
                    Text = text
                }).ToList() ?? new List<Instruction>()
            };
            
            db.Recipes.Add(recipe);
            count++;
            Console.WriteLine($"  ✓ Added: {recipe.Title}");
        }
        
        await db.SaveChangesAsync();
        Console.WriteLine($"\n✅ Successfully imported {count} recipe(s)");
    }
    catch (JsonException ex)
    {
        Console.WriteLine($"Error parsing JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

async Task ListRecipes(string[] args)
{
    var dbPath = GetDbPath(args);
    
    Console.WriteLine($"Database: {dbPath}");
    Console.WriteLine();
    
    if (!File.Exists(dbPath))
    {
        Console.WriteLine("Database not found");
        return;
    }
    
    await using var db = CreateDbContext(dbPath);
    var recipes = await db.Recipes.OrderBy(r => r.Title).ToListAsync();
    
    if (recipes.Count == 0)
    {
        Console.WriteLine("No recipes in database");
        return;
    }
    
    Console.WriteLine($"Found {recipes.Count} recipe(s):\n");
    
    foreach (var recipe in recipes)
    {
        var fav = recipe.IsFavorite ? "❤️" : "";
        var total = recipe.PrepTime + recipe.CookTime;
        Console.WriteLine($"  {fav} {recipe.Title}");
        Console.WriteLine($"     Cuisine: {recipe.CuisineType} | Difficulty: {recipe.Difficulty}");
        Console.WriteLine($"     Time: {total.TotalMinutes}min | Servings: {recipe.Servings}");
        Console.WriteLine($"     Ingredients: {recipe.Ingredients.Count} | Steps: {recipe.Instructions.Count}");
        Console.WriteLine();
    }
}

async Task ExportRecipes(string[] args)
{
    var outputFile = args[1];
    var dbPath = GetDbPath(args);
    
    Console.WriteLine($"Database: {dbPath}");
    Console.WriteLine($"Exporting to: {outputFile}");
    
    if (!File.Exists(dbPath))
    {
        Console.WriteLine("Database not found");
        return;
    }
    
    await using var db = CreateDbContext(dbPath);
    var recipes = await db.Recipes.OrderBy(r => r.Title).ToListAsync();
    
    var exportData = new ImportData
    {
        Recipes = recipes.Select(r => new ImportRecipe
        {
            Title = r.Title,
            Description = r.Description,
            ImageUrl = r.ImageUrl,
            PrepTimeMinutes = (int)r.PrepTime.TotalMinutes,
            CookTimeMinutes = (int)r.CookTime.TotalMinutes,
            Servings = r.Servings,
            Difficulty = r.Difficulty.ToString(),
            CuisineType = r.CuisineType,
            IsFavorite = r.IsFavorite,
            Ingredients = r.Ingredients.Select(i => new ImportIngredient
            {
                Name = i.Name,
                Amount = i.Amount,
                Unit = i.Unit
            }).ToList(),
            Instructions = r.Instructions.OrderBy(i => i.StepNumber).Select(i => i.Text).ToList()
        }).ToList()
    };
    
    var json = JsonSerializer.Serialize(exportData, new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });
    
    await File.WriteAllTextAsync(outputFile, json);
    Console.WriteLine($"\n✅ Exported {recipes.Count} recipe(s)");
}

string GetDbPath(string[] args)
{
    for (int i = 0; i < args.Length - 1; i++)
    {
        if (args[i] == "--db")
        {
            return args[i + 1];
        }
    }
    return "data/culinaryvault.db";
}

RecipeDbContext CreateDbContext(string dbPath)
{
    var options = new DbContextOptionsBuilder<RecipeDbContext>()
        .UseSqlite($"Data Source={dbPath}")
        .Options;
    return new RecipeDbContext(options);
}

class RecipeDbContext : DbContext
{
    public DbSet<Recipe> Recipes => Set<Recipe>();

    public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var recipe = modelBuilder.Entity<Recipe>();
        recipe.HasKey(r => r.Id);
        
        recipe.Property(r => r.Ingredients)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<Ingredient>>(v, (JsonSerializerOptions?)null) ?? new List<Ingredient>()
            )
            .HasColumnType("TEXT");

        recipe.Property(r => r.Instructions)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<Instruction>>(v, (JsonSerializerOptions?)null) ?? new List<Instruction>()
            )
            .HasColumnType("TEXT");
    }
}

class ImportData
{
    public List<ImportRecipe> Recipes { get; set; } = new();
}

class ImportRecipe
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public int PrepTimeMinutes { get; set; }
    public int CookTimeMinutes { get; set; }
    public int Servings { get; set; }
    public string? Difficulty { get; set; }
    public string? CuisineType { get; set; }
    public bool IsFavorite { get; set; }
    public List<ImportIngredient>? Ingredients { get; set; }
    public List<string>? Instructions { get; set; }
}

class ImportIngredient
{
    public string? Name { get; set; }
    public double Amount { get; set; }
    public string? Unit { get; set; }
}
