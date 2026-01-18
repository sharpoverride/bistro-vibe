# 🍳 Culinary Vault (Cămara Culinară)

A Romanian-themed recipe management web application built with .NET 10 Blazor.

## Features

- **Recipe Browsing** - Masonry grid layout with search and filtering
- **Recipe Details** - Full recipe view with ingredient scaling
- **Focus Mode** - Distraction-free cooking assistant with wake lock support
- **Favorites** - Mark and quickly access favorite recipes
- **Cuisine Categories** - Dynamic sidebar navigation by cuisine type
- **CRUD Operations** - Create, edit, and delete recipes
- **Responsive Design** - Mobile-first with touch optimization

## Tech Stack

- **.NET 10** with Blazor Server + WebAssembly hybrid
- **Entity Framework Core** with SQLite
- **Tailwind-inspired CSS** styling
- **Docker** with persistent volumes
- **Tailscale** integration for secure remote access

## Getting Started

### Prerequisites

- .NET 10 SDK
- Docker (optional, for containerized deployment)

### Development

```bash
# Clone and build
git clone <repository>
cd bistro-vibe
dotnet build

# Run the application
dotnet run --project CulinaryVault

# Access at http://localhost:5031
```

### Docker Deployment

```bash
# Build and run with Docker Compose
docker-compose up -d

# Access at http://localhost:5031
```

## Project Structure

```
bistro-vibe/
├── CulinaryVault/              # Main Blazor Server app
│   ├── Components/             # Razor components
│   │   ├── Layout/             # MainLayout
│   │   ├── Pages/              # Route pages
│   │   └── Shared/             # Reusable components
│   ├── Controllers/            # REST API endpoints
│   ├── Data/                   # DbContext & seed data
│   ├── Services/               # Business logic
│   └── wwwroot/                # Static assets
├── CulinaryVault.Client/       # WebAssembly client
├── CulinaryVault.Shared/       # Shared models
├── CulinaryVault.Tests/        # Unit tests
├── RecipeImporter/             # CLI import tool
├── Dockerfile
└── docker-compose.yml
```

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/recipes | Get all recipes |
| GET | /api/recipes/{id} | Get recipe by ID |
| POST | /api/recipes | Create recipe |
| PUT | /api/recipes/{id} | Update recipe |
| DELETE | /api/recipes/{id} | Delete recipe |
| GET | /api/recipes/search?term= | Search recipes |
| POST | /api/recipes/{id}/favorite | Toggle favorite |
| GET | /api/recipes/favorites | Get favorites |
| GET | /api/recipes/cuisine-types | Get all cuisine types |
| GET | /api/recipes/cuisine/{type} | Get by cuisine |
| POST | /api/upload/image | Upload recipe image |

## Recipe Importer CLI

```bash
# Import recipes from JSON
dotnet run --project RecipeImporter -- import recipes.json

# List all recipes
dotnet run --project RecipeImporter -- list

# Export recipes to JSON
dotnet run --project RecipeImporter -- export backup.json

# Specify database path
dotnet run --project RecipeImporter -- list --db path/to/db.sqlite
```

## Localization

The application uses Romanian (ro-RO) throughout:
- **Acasă** - Home
- **Rețetă Nouă** - New Recipe
- **Favorite** - Favorites
- **Ingrediente** - Ingredients
- **Instrucțiuni** - Instructions
- **Porții** - Servings
- **Dificultate** - Difficulty

## Design

- **Primary Color**: #2C3E50 (dark blue-gray)
- **Accent Color**: #E74C3C (coral red)
- **Font**: Playfair Display for titles

## License

MIT
