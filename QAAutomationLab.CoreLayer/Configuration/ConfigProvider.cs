using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace QAAutomationLab.CoreLayer.Configuration
{
    public static class ConfigProvider
    {
        public static IConfigurationRoot GetConfigRoot()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            builder.Add(new EnvironmentVariablesConfigurationSource());
            return builder.Build();
        }
    }
}
