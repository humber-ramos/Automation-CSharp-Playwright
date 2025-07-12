using Microsoft.Playwright;

namespace PlaywrightE2E.Pages
{
    public class LogInModal
    {
        private readonly IPage _page;
        private ILocator usernameField => _page.Locator("#loginusername");
        private ILocator passwordField => _page.Locator("#loginpassword");
        private ILocator logInButton => _page.GetByRole(AriaRole.Button, new() { Name = "Log In" });

        public LogInModal(IPage page)
        {
            _page = page;
        }

        public async Task FillData(string username, string password)
        {
            await usernameField.WaitForAsync();
            await usernameField.FillAsync(username);
            await passwordField.FillAsync(password);
        }

        public async Task ClickOnLogIn()
        {
            await logInButton.ClickAsync();
        }
    }
}
