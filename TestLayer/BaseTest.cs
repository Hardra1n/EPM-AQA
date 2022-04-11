using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.Services;
using QAAutomationLab.CoreLayer.Logging;

namespace TestLayer
{
    public class BaseTest
    {
        private IWebDriver _driver;

        private ReportPortalLogger _logger;

        protected TestSettings TestsSettings { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _logger = ReportPortalLogger.GetInstance();
            TestsSettings = SettingsService<TestSettings>.GetSettings();
        }

        [SetUp]
        public void SetUp()
        {
            DriverSettingService.SetPathToDriver();
            _driver = QAAutomationLab.CoreLayer.Driver.Driver.GetInstance();
            _logger.Logger.Information($"{TestContext.CurrentContext.Test.Name} successfully started.");
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                _logger.Logger.Error(TestContext.CurrentContext.Result.Message);
            }
            else
            {
                _logger.Logger.Information($"{TestContext.CurrentContext.Test.Name} executed successfully.");
            }

            QAAutomationLab.CoreLayer.Driver.Driver.Quit();
        }
    }
}
