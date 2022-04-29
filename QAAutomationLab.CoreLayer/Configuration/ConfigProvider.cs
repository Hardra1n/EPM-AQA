using Microsoft.Extensions.Configuration;

namespace QAAutomationLab.CoreLayer.Configuration
{
    public static class ConfigProvider
    {
        public static IConfigurationRoot GetConfigRoot()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            return builder.Build();
        }
    }
}
