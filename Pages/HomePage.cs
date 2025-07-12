using Microsoft.Playwright;

namespace PlaywrightE2E.Pages
{
    public class HomePage
    {
        private readonly IPage _page;

        private ILocator LoginButton => _page.Locator("#login2");
        private ILocator phonesButton => _page.GetByRole(AriaRole.Link, new() { Name = "Phones" });
        private ILocator laptopsButton => _page.GetByRole(AriaRole.Link, new() { Name = "Laptops" });
        private ILocator monitorsButton => _page.GetByRole(AriaRole.Link, new() { Name = "Monitors" });
        private ILocator nokiaLumiaOption => _page.GetByRole(AriaRole.Link, new() { Name = "Nokia lumia" });
        private ILocator homeButton => _page.GetByRole(AriaRole.Link, new() { Name = "Home" });
        private ILocator HTCOption => _page.GetByRole(AriaRole.Link, new() { Name = "HTC One M9" });
        private ILocator sonyVaioOption => _page.GetByRole(AriaRole.Link, new() { Name = "Sony vaio i7" });
        private ILocator macBookProOption => _page.GetByRole(AriaRole.Link, new() { Name = "MacBook Pro" });
        private ILocator appleMonitorOption => _page.GetByRole(AriaRole.Link, new() { Name = "Apple monitor 24" });
        private ILocator cartButton => _page.Locator("#cartur");
        private ILocator logOutButton => _page.GetByRole(AriaRole.Link, new() { Name = "Log out" });


        public HomePage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateAsync(string url)
        {
            await _page.GotoAsync(url);
        }
        public async Task OpenLoginModalAsync()
        {
            await LoginButton.WaitForAsync();
            await LoginButton.ClickAsync();
        }
        public async Task selectPhonesCategory()
        {
            await phonesButton.WaitForAsync();
            await phonesButton.ClickAsync();
        }
        public async Task selectLaptopsCategory()
        {
            await laptopsButton.WaitForAsync();
            await laptopsButton.ClickAsync();
        }
        public async Task selectMonitorsCategory()
        {
            await monitorsButton.WaitForAsync();
            await monitorsButton.ClickAsync();
        }
        public async Task clickNokiaLumiaOption()
        {
            await nokiaLumiaOption.WaitForAsync();
            await nokiaLumiaOption.ClickAsync();
        }
        public async Task clickHomeButton()
        {
            await homeButton.ClickAsync();
        }
        public async Task scrollDown()
        {
            await _page.EvaluateAsync("() => window.scrollTo(0, document.body.scrollHeight)");
        }
        public async Task clickHTCOption()
        {
            await HTCOption.WaitForAsync();
            await HTCOption.ClickAsync();
        }
        public async Task clickSonyVaioOption()
        {
            await sonyVaioOption.WaitForAsync();
            await sonyVaioOption.ClickAsync();
        }
        public async Task clickMacBookProOption()
        {
            await macBookProOption.WaitForAsync();
            await macBookProOption.ClickAsync();
        }
        public async Task clickAppleMonitorOption()
        {
            await appleMonitorOption.WaitForAsync();
            await appleMonitorOption.ClickAsync();
        }
        public async Task clickCart()
        {
            await cartButton.ClickAsync();
        }
        public async Task clickLogOutButton()
        {
            await logOutButton.ClickAsync();
        }
    }
}
