using Microsoft.Playwright;
using PlaywrightE2E.Config;

namespace PlaywrightE2E.Drivers

{
    public class PlaywrightDriver
    {
        public IPlaywright Playwright { get; private set; }
        public IBrowser Browser { get; private set; }
        public IBrowserContext Context { get; private set; }
        public IPage Page { get; private set; }
        public TestSettings Settings { get; private set; }

        public PlaywrightDriver()
        {
            Settings = PlaywrightE2E.Config.ConfigReader.LoadSettings();
        }

        public async Task InitializeAsync()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
                SlowMo = 1000
            });

            Context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1500,
                    Height = 800
                },
                RecordVideoDir = "videos", 
                RecordVideoSize = new() { Width = 1980, Height = 1080 }
            });
            Page = await Context.NewPageAsync();

        }

        public async Task DisposeAsync()
        {
            if (Context != null)
                await Context.CloseAsync();

            if (Browser != null)
                await Browser.CloseAsync();

            if (Playwright != null)
                Playwright.Dispose();
        }
    }
}
