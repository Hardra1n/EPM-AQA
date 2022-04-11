using QAAutomationLab.BusinessLayer.Utilities;
using QAAutomationLab.CoreLayer.Driver;

namespace QAAutomationLab.BusinessLayer.Services
{
    public static class DriverSettingService
    {
        public static void SetPathToDriver()
        {
            var pathToDriver = PathUtility.GetDriverPath();

            Driver.PathToDriver = pathToDriver;
        }
    }
}
