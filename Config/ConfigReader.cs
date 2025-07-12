using Microsoft.Extensions.Configuration;

namespace PlaywrightE2E.Config
{
    public static class ConfigReader
    {
        public static TestSettings LoadSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var settings = new TestSettings();
            config.Bind(settings);
            return settings;
        }
    }
}