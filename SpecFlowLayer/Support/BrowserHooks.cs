using QAAutomationLab.BusinessLayer.Services;
using QAAutomationLab.CoreLayer.Driver;
using TechTalk.SpecFlow;

namespace SpecFlowLayer.Support
{
    [Binding]
    public class BrowserHooks
    {
        [BeforeScenario("browser")]
        public void InitializeDriver()
        {
            DriverSettingService.SetPathToDriver();
            Driver.GetInstance();
        }

        [AfterScenario("browser")]
        public void CloseDriver()
        {
            Driver.Quit();
        }
    }
}
