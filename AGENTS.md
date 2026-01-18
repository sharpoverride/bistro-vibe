# Culinary Vault (Cămara Culinară)

## Quick Commands

```bash
# Build the solution
dotnet build

# Run the main web application
dotnet run --project CulinaryVault

# Run tests
dotnet test

# Run the RecipeImporter CLI
dotnet run --project RecipeImporter -- help
dotnet run --project RecipeImporter -- list --db CulinaryVault/data/culinaryvault.db
dotnet run --project RecipeImporter -- import recipes.json --db CulinaryVault/data/culinaryvault.db

# Docker
docker-compose build
docker-compose up -d
docker-compose down
```

## Project Structure

- **CulinaryVault/** - Main Blazor Server web application
- **CulinaryVault.Client/** - WebAssembly client for hybrid rendering
- **CulinaryVault.Shared/** - Shared models (Recipe, Ingredient, Instruction, IRecipeService)
- **CulinaryVault.Tests/** - xUnit tests
- **RecipeImporter/** - CLI tool for importing/exporting recipes

## Technology Stack

- .NET 10 (Blazor with Interactive Server rendering)
- Entity Framework Core with SQLite
- Tailwind-style CSS (custom implementation in app.css)
- Docker with persistent volumes

## Key Patterns

- **IRecipeService** interface for all recipe operations
- **RecipeService** implementation with EF Core
- JSON columns for Ingredients and Instructions stored as TEXT in SQLite
- Romanian localization throughout the UI

## Database

SQLite database at `data/culinaryvault.db`
- Connection string: `Data Source=data/culinaryvault.db`
- Auto-creates on first run
- Seeds with sample Romanian recipes

## Code Style

- Use Romanian text for UI labels
- Follow existing component patterns in Components/Shared/
- Use async/await for all database operations
- Touch-optimized with `@ontouchend` handlers for mobile
