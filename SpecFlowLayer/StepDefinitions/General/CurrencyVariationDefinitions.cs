using NUnit.Framework;
using QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects;
using QAAutomationLab.CoreLayer.BasePage;
using TechTalk.SpecFlow;

namespace SpecFlowLayer.StepDefinitions.General
{
    [Binding]
    public class CurrencyVariationDefinitions : BaseDefinitions
    {
        public CurrencyVariationDefinitions(ScenarioContext scenarioContext) 
            : base(scenarioContext) { }

        [Given(@"user opened currancy changing tab")]
        [When(@"user opens currency changing tab")]
        public void OpenCurrencyChangingTab()
        {
            var page = (MainPage)Page;
            Page = page.MainPageTopBar.ClickCurrencyVariationButton();
        }

        [Given(@"user chose '(.*)' currency")]
        [When(@"user chooses '(.*)' currency")]
        public void ChangeCurrency(string currency)
        {
            var page = (CurrencyVariationBar)Page;
            Page = page.ChooseCurrency(currency);
        }
    }
}
