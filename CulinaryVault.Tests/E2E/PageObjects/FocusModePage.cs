using Microsoft.Playwright;

namespace CulinaryVault.Tests.E2E.PageObjects;

public class FocusModePage
{
    private readonly IPage _page;

    public FocusModePage(IPage page)
    {
        _page = page;
    }

    // Selectors
    private ILocator InstructionText => _page.Locator("[data-testid='focus-instruction'], .focus-instruction, .instruction-text").First;
    private ILocator PreviousButton => _page.Locator("button:has-text('Înapoi'), button:has-text('Previous'), button:has(svg[data-lucide='chevron-left'])").First;
    private ILocator NextButton => _page.Locator("button:has-text('Înainte'), button:has-text('Next'), button:has(svg[data-lucide='chevron-right'])").First;
    private ILocator CloseButton => _page.Locator("button:has-text('Închide'), button:has(svg[data-lucide='x']), [data-testid='close-focus']").First;
    private ILocator ProgressDots => _page.Locator("[data-testid='progress-dot'], .progress-dot, .dot");
    private ILocator StepIndicator => _page.Locator("[data-testid='step-indicator'], .step-indicator");

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
        return await InstructionText.IsVisibleAsync();
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
