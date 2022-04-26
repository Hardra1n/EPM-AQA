using QAAutomationLab.BusinessLayer.Services;
using QAAutomationLab.BusinessLayer.Utilities;
using QAAutomationLab.CoreLayer.Driver;
using TechTalk.SpecFlow;

namespace SpecFlowLayer.Support
{
    [Binding]
    public class BrowserHooks
    {
        private ScenarioContext _scenarioContext;

        public BrowserHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("browser")]
        public void InitializeDriver()
        {
            DriverSettingService.SetPathToDriver();
            Driver.GetInstance();
            _scenarioContext.Add("MainPage", Utilities.RunBrowser("https://booking.com/"));
        }

        [AfterScenario("browser")]
        public void CloseDriver()
        {
            Driver.Quit();
        }
    }
}
