using CulinaryVault.Components;
using CulinaryVault.Data;
using CulinaryVault.Services;
using CulinaryVault.Shared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure SQLite Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=data/culinaryvault.db";

// Ensure data directory exists
var dataDir = Path.GetDirectoryName(connectionString.Replace("Data Source=", ""));
if (!string.IsNullOrEmpty(dataDir) && !Directory.Exists(dataDir))
{
    Directory.CreateDirectory(dataDir);
}

builder.Services.AddDbContext<CulinaryVaultDbContext>(options =>
    options.UseSqlite(connectionString));

// Register application services
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddSingleton<AppState>();

// Add Blazor services with interactive server rendering
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Configure HttpClient for hybrid rendering and file uploads
builder.Services.AddHttpClient("CulinaryVault.Api", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"] ?? "https://localhost:5031/");
});
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CulinaryVault.Api"));

// Add controllers for API endpoints
builder.Services.AddControllers();

var app = builder.Build();

// Initialize database and seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CulinaryVaultDbContext>();
    db.Database.EnsureCreated();
    await SeedData.InitializeAsync(db);
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

// Map API controllers
app.MapControllers();

// Map Blazor components - using server-side rendering with optional WASM
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(CulinaryVault.Client._Imports).Assembly);

app.Run();
