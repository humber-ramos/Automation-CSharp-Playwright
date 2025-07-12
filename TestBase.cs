using PlaywrightE2E.Drivers;
using PlaywrightE2E.Config;
using Allure.Xunit.Attributes;
using PlaywrightE2E.Pages;

namespace PlaywrightE2E
{
    [AllureSuite("E2E Checkout Flow")]
    public class TestBase : IAsyncLifetime
    {
        protected readonly PlaywrightDriver Driver;
        protected TestSettings Settings => Driver.Settings;

        protected LogInModal LogInModal;
        protected HomePage HomePage;

        public TestBase()
        {
            Driver = new PlaywrightDriver();
        }

        public async Task InitializeAsync()
        {
            await Driver.InitializeAsync();

            var homePage = new HomePage(Driver.Page);
            var logInModal = new LogInModal(Driver.Page);

            await homePage.NavigateAsync(Settings.BaseUrl);
            await homePage.OpenLoginModalAsync();
            await logInModal.FillData(Settings.Username, Settings.Password);
            await logInModal.ClickOnLogIn();
        }

        public async Task DisposeAsync()
        {
            var homePage = new HomePage(Driver.Page);
            
            await homePage.clickLogOutButton();
            await Driver.DisposeAsync();
        }
    }
}