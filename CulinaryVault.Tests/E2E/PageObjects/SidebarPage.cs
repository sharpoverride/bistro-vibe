using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E.PageObjects;

public class SidebarPage
{
    private readonly IPage _page;

    public SidebarPage(IPage page)
    {
        _page = page;
    }

    // Selectors using data-testid
    private ILocator Sidebar => _page.Locator("[data-testid='sidebar']");
    private ILocator SidebarHeader => _page.Locator("[data-testid='sidebar-header']");
    private ILocator LogoText => _page.Locator("[data-testid='sidebar-logo-text']");
    private ILocator SidebarNav => _page.Locator("[data-testid='sidebar-nav']");
    private ILocator NavigationLinks => _page.Locator("[data-testid='sidebar-nav'] .nav-link");
    private ILocator MainContent => _page.Locator("[data-testid='main-content']");

    public async Task NavigateAsync()
    {
        await _page.GotoAsync("/");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task ToggleSidebarAsync()
    {
        await SidebarHeader.ClickAsync();
        // Wait for CSS transition to complete (300ms defined in CSS)
        await _page.WaitForTimeoutAsync(350);
    }

    public async Task<bool> IsSidebarCollapsedAsync()
    {
        var classAttribute = await Sidebar.GetAttributeAsync("class");
        return classAttribute?.Contains("collapsed") ?? false;
    }

    public async Task<bool> IsLogoTextVisibleAsync()
    {
        try
        {
            return await LogoText.IsVisibleAsync();
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> IsNavigationTextVisibleAsync()
    {
        try
        {
            var firstNavText = NavigationLinks.First.Locator("span");
            return await firstNavText.IsVisibleAsync();
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> AreNavigationIconsVisibleAsync()
    {
        try
        {
            var firstIcon = NavigationLinks.First.Locator("svg");
            return await firstIcon.IsVisibleAsync();
        }
        catch
        {
            return false;
        }
    }

    public async Task<double> GetSidebarWidthAsync()
    {
        var boundingBox = await Sidebar.BoundingBoxAsync();
        return boundingBox?.Width ?? 0;
    }

    public async Task<double> GetMainContentMarginLeftAsync()
    {
        var marginLeft = await MainContent.EvaluateAsync<string>("el => getComputedStyle(el).marginLeft");
        // Parse "240px" to 240
        if (double.TryParse(marginLeft.Replace("px", ""), out var value))
        {
            return value;
        }
        return 0;
    }

    public async Task<bool> IsSidebarVisibleAsync()
    {
        return await Sidebar.IsVisibleAsync();
    }
}
