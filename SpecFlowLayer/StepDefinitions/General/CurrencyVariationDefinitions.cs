using NUnit.Framework;
using QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects;
using QAAutomationLab.CoreLayer.BasePage;
using TechTalk.SpecFlow;

namespace SpecFlowLayer.StepDefinitions.General
{
    [Binding]
    public class CurrencyVariationDefinitions
    {
        private BasePage _page;

        private ScenarioContext _scenarioContext;

        public CurrencyVariationDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _page = (MainPage)_scenarioContext["MainPage"];
        }

        [Given(@"user opened currancy changing tab")]
        [When(@"user opens currency changing tab")]
        public void OpenCurrencyChangingTab()
        {
            MainPage page = (MainPage)_page;
            _page = page.MainPageTopBar.ClickCurrencyVariationButton();
        }

        [Given(@"user chose '(.*)' currency")]
        [When(@"user chooses '(.*)' currency")]
        public void ChangeCurrency(string currency)
        {
            CurrencyVariationBar page = (CurrencyVariationBar)_page;
            _page = page.ChooseCurrency(currency);
            _scenarioContext["MainPage"] = (MainPage)_page;
        }
    }
}
