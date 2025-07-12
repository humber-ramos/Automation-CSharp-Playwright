using Microsoft.Playwright;
using PlaywrightE2E.Config;
using PlaywrightE2E.Drivers;

namespace PlaywrightE2E.Pages
{
    public class OrderConfirmationModal
    {
        private readonly IPage _page;
        protected readonly PlaywrightDriver Driver;
        protected TestSettings Settings => Driver.Settings;

        private ILocator confirmationMessage => _page.GetByText(Settings.Message);
        private ILocator OKButton => _page.GetByRole(AriaRole.Button, new() { Name = "OK" });
        
        public OrderConfirmationModal(IPage page)
        {
            _page = page;
            Driver = new PlaywrightDriver();
        }

        public async Task<bool> orderIsConfirmed()
        {
            await confirmationMessage.WaitForAsync();
            var messageIsDisplayed = await confirmationMessage.IsVisibleAsync();
            return messageIsDisplayed;
        }
        public async Task clickOKButton()
        {
            await OKButton.ClickAsync();
        }
    }
}