using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.Services;
using QAAutomationLab.CoreLayer.Logging;

namespace TestLayer
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        protected ReportPortalLogger Logger;

        protected TestSettings TestsSettings;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Logger = ReportPortalLogger.GetInstance();
            TestsSettings = SettingsService<TestSettings>.GetSettings();
        }

        [SetUp]
        public void SetUp()
        {
            Driver = QAAutomationLab.CoreLayer.Driver.Driver.GetInstance();
            Logger.Logger.Information($"{TestContext.CurrentContext.Test.Name} successfully started.");
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Logger.Logger.Error(TestContext.CurrentContext.Result.Message);
            }
            else
            {
                Logger.Logger.Information($"{TestContext.CurrentContext.Test.Name} executed successfully.");
            }

            QAAutomationLab.CoreLayer.Driver.Driver.Quit();
        }
    }
}
