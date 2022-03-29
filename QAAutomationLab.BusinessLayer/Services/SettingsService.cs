using Newtonsoft.Json;
using QAAutomationLab.BusinessLayer.Utilities;
using QAAutomationLab.CoreLayer.Driver;
using System.IO;

namespace QAAutomationLab.BusinessLayer.Services
{
    public static class SettingsService<T>
    {
        public static T GetSettings()
        {
            var pathToData = PathUtility.GetSettingsPath();

            var file = File.ReadAllText(pathToData);

            var settings = JsonConvert.DeserializeObject<T>(file);

            return settings;
        }

        public static void SetPathToDriver()
        {
            var pathToDriver = PathUtility.GetDriverPath();

            Driver.PathToDriver = pathToDriver;
        }
    }
}
