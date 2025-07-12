using Microsoft.Playwright;
using PlaywrightE2E.Config;
using PlaywrightE2E.Drivers;

namespace PlaywrightE2E.Pages
{
    public class OrderForm
    {
        private readonly IPage _page;
        protected readonly PlaywrightDriver Driver;
        protected TestSettings Settings => Driver.Settings;

        private ILocator nameField => _page.Locator("#name");
        private ILocator countryField => _page.Locator("#country");
        private ILocator cityField => _page.Locator("#city");
        private ILocator creditCardField => _page.Locator("#card");
        private ILocator monthField => _page.Locator("#month");
        private ILocator yearField => _page.Locator("#year");
        private ILocator purchaseButton => _page.GetByRole(AriaRole.Button, new() { Name = "Purchase" });
        private ILocator closeButton => _page.GetByRole(AriaRole.Button, new() { Name = "Close"}).First;

        public OrderForm(IPage page)
        {
            _page = page;
            Driver = new PlaywrightDriver();
        }

        public async Task FillNameField()
        {
            await nameField.WaitForAsync();
            await nameField.FillAsync(Settings.Name);
        }
        public async Task FillCountryField()
        {
            await countryField.FillAsync(Settings.Country);
        }
        public async Task FillCityField()
        {
            await cityField.FillAsync(Settings.City);
        }
        public async Task FillCreditCardField()
        {
            await creditCardField.FillAsync(Settings.CreditCard);
        }
        public async Task FillMonthField()
        {
            await monthField.FillAsync(Settings.Month);
        }
        public async Task FillYearField()
        {
            await yearField.FillAsync(Settings.Year);
        }
        public async Task clickPurchaseButton()
        {
            await purchaseButton.ClickAsync();
        }
        public async Task pressTab()
        {
            await _page.Keyboard.PressAsync("Tab");
        }
        public async Task clickCloseButton()
        {
            if (await closeButton.IsVisibleAsync())
            {
                await closeButton.ClickAsync();
            }
            
        }
    }
}