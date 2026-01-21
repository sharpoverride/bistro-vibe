namespace CulinaryVault.Services;

public class AppState
{
    public event Action? OnRecipeDeleted;
    public event Action? OnRecipeCreated;
    public event Action? OnRecipeUpdated;

    public void NotifyRecipeDeleted()
    {
        OnRecipeDeleted?.Invoke();
    }

    public void NotifyRecipeCreated()
    {
        OnRecipeCreated?.Invoke();
    }

    public void NotifyRecipeUpdated()
    {
        OnRecipeUpdated?.Invoke();
    }
}
