using CulinaryVault.Tests.E2E.Fixtures;
using CulinaryVault.Tests.E2E.PageObjects;
using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E;

[Collection("Playwright")]
public class SidebarToggleTests : IClassFixture<PlaywrightFixture>
{
    private readonly PlaywrightFixture _fixture;

    public SidebarToggleTests(PlaywrightFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Sidebar_ClickHeader_CollapsesSidebar()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var sidebarPage = new SidebarPage(page);
        await sidebarPage.NavigateAsync();

        // Assert initial state - sidebar is expanded
        var isCollapsedBefore = await sidebarPage.IsSidebarCollapsedAsync();
        isCollapsedBefore.Should().BeFalse("Sidebar should be expanded initially");

        // Act - click on sidebar header to collapse
        await sidebarPage.ToggleSidebarAsync();

        // Assert - sidebar is now collapsed
        var isCollapsedAfter = await sidebarPage.IsSidebarCollapsedAsync();
        isCollapsedAfter.Should().BeTrue("Sidebar should be collapsed after clicking header");
    }

    [Fact]
    public async Task Sidebar_ClickHeaderTwice_ExpandsSidebar()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var sidebarPage = new SidebarPage(page);
        await sidebarPage.NavigateAsync();

        // Act - collapse then expand
        await sidebarPage.ToggleSidebarAsync();
        await sidebarPage.ToggleSidebarAsync();

        // Assert - sidebar is expanded again
        var isCollapsed = await sidebarPage.IsSidebarCollapsedAsync();
        isCollapsed.Should().BeFalse("Sidebar should be expanded after toggling twice");
    }

    [Fact]
    public async Task Sidebar_WhenCollapsed_HidesNavigationText()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var sidebarPage = new SidebarPage(page);
        await sidebarPage.NavigateAsync();

        // Act - collapse sidebar
        await sidebarPage.ToggleSidebarAsync();

        // Assert - navigation text should be hidden
        var isNavTextVisible = await sidebarPage.IsNavigationTextVisibleAsync();
        isNavTextVisible.Should().BeFalse("Navigation text should be hidden when sidebar is collapsed");
    }

    [Fact]
    public async Task Sidebar_WhenCollapsed_ShowsOnlyIcons()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var sidebarPage = new SidebarPage(page);
        await sidebarPage.NavigateAsync();

        // Act - collapse sidebar
        await sidebarPage.ToggleSidebarAsync();

        // Assert - icons should still be visible
        var areIconsVisible = await sidebarPage.AreNavigationIconsVisibleAsync();
        areIconsVisible.Should().BeTrue("Navigation icons should remain visible when sidebar is collapsed");
    }

    [Fact]
    public async Task Sidebar_WhenExpanded_ShowsLogoText()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var sidebarPage = new SidebarPage(page);
        await sidebarPage.NavigateAsync();

        // Assert - logo text should be visible when expanded
        var isLogoTextVisible = await sidebarPage.IsLogoTextVisibleAsync();
        isLogoTextVisible.Should().BeTrue("Logo text should be visible when sidebar is expanded");
    }

    [Fact]
    public async Task Sidebar_WhenCollapsed_HidesLogoText()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var sidebarPage = new SidebarPage(page);
        await sidebarPage.NavigateAsync();

        // Act - collapse sidebar
        await sidebarPage.ToggleSidebarAsync();

        // Assert - logo text should be hidden when collapsed
        var isLogoTextVisible = await sidebarPage.IsLogoTextVisibleAsync();
        isLogoTextVisible.Should().BeFalse("Logo text should be hidden when sidebar is collapsed");
    }

    [Fact]
    public async Task Sidebar_WidthChangesOnToggle()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var sidebarPage = new SidebarPage(page);
        await sidebarPage.NavigateAsync();

        // Get initial width
        var expandedWidth = await sidebarPage.GetSidebarWidthAsync();

        // Act - collapse sidebar
        await sidebarPage.ToggleSidebarAsync();
        await page.WaitForTimeoutAsync(400); // Wait for animation

        // Get collapsed width
        var collapsedWidth = await sidebarPage.GetSidebarWidthAsync();

        // Assert
        collapsedWidth.Should().BeLessThan(expandedWidth, "Collapsed sidebar should be narrower than expanded");
    }

    [Fact]
    public async Task MainContent_AdjustsMarginOnSidebarToggle()
    {
        // Arrange
        var page = await _fixture.CreatePageAsync();
        var sidebarPage = new SidebarPage(page);
        await sidebarPage.NavigateAsync();

        // Get initial margin
        var expandedMargin = await sidebarPage.GetMainContentMarginLeftAsync();

        // Act - collapse sidebar
        await sidebarPage.ToggleSidebarAsync();
        await page.WaitForTimeoutAsync(400); // Wait for animation

        // Get new margin
        var collapsedMargin = await sidebarPage.GetMainContentMarginLeftAsync();

        // Assert
        collapsedMargin.Should().BeLessThan(expandedMargin, "Main content margin should decrease when sidebar is collapsed");
    }
}
