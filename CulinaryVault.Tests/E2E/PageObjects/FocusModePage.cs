using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E.PageObjects;

public class FocusModePage
{
    private readonly IPage _page;

    public FocusModePage(IPage page)
    {
        _page = page;
    }

    // Selectors using data-testid
    private ILocator FocusModeOverlay => _page.Locator("[data-testid='focus-mode-overlay']");
    private ILocator InstructionText => _page.Locator("[data-testid='focus-mode-instruction']");
    private ILocator StepIndicator => _page.Locator("[data-testid='focus-mode-step-indicator']");
    private ILocator PreviousButton => _page.Locator("[data-testid='focus-mode-prev']");
    private ILocator NextButton => _page.Locator("[data-testid='focus-mode-next']");
    private ILocator CloseButton => _page.Locator("[data-testid='focus-mode-close']");
    private ILocator ProgressDots => _page.Locator("[data-testid='focus-mode-dot']");

    public async Task<string> GetCurrentInstructionAsync()
    {
        return await InstructionText.TextContentAsync() ?? "";
    }

    public async Task GoToNextStepAsync()
    {
        await NextButton.ClickAsync();
        await _page.WaitForTimeoutAsync(200);
    }

    public async Task GoToPreviousStepAsync()
    {
        await PreviousButton.ClickAsync();
        await _page.WaitForTimeoutAsync(200);
    }

    public async Task CloseAsync()
    {
        await CloseButton.ClickAsync();
        await _page.WaitForTimeoutAsync(300);
    }

    public async Task<int> GetProgressDotCountAsync()
    {
        return await ProgressDots.CountAsync();
    }

    public async Task ClickProgressDotAsync(int index)
    {
        await ProgressDots.Nth(index).ClickAsync();
        await _page.WaitForTimeoutAsync(200);
    }

    public async Task<bool> IsVisibleAsync()
    {
        return await FocusModeOverlay.IsVisibleAsync();
    }

    public async Task<bool> IsPreviousButtonEnabledAsync()
    {
        return await PreviousButton.IsEnabledAsync();
    }

    public async Task<bool> IsNextButtonEnabledAsync()
    {
        return await NextButton.IsEnabledAsync();
    }

    public async Task<string> GetStepIndicatorTextAsync()
    {
        return await StepIndicator.TextContentAsync() ?? "";
    }

    public async Task PressEscapeAsync()
    {
        await _page.Keyboard.PressAsync("Escape");
        await _page.WaitForTimeoutAsync(300);
    }

    public async Task PressArrowRightAsync()
    {
        await _page.Keyboard.PressAsync("ArrowRight");
        await _page.WaitForTimeoutAsync(200);
    }

    public async Task PressArrowLeftAsync()
    {
        await _page.Keyboard.PressAsync("ArrowLeft");
        await _page.WaitForTimeoutAsync(200);
    }
}
