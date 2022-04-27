using QAAutomationLab.BusinessLayer.Services;
using QAAutomationLab.BusinessLayer.Utilities;
using QAAutomationLab.CoreLayer.BasePage;
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
            BasePage page = Utilities.RunBrowser("https://www.booking.com/");
            _scenarioContext.Add("MainPage", page);
        }

        [AfterScenario("browser")]
        public void CloseDriver()
        {
            Driver.Quit();
        }
    }
}
