using NUnit.Framework;
using QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects;
using QAAutomationLab.CoreLayer.BasePage;
using TechTalk.SpecFlow;

namespace SpecFlowLayer.StepDefinitions.General
{
    [Binding]
    public class LanguageVariationDefinitions
    {
        private BasePage _page;

        public LanguageVariationDefinitions(ScenarioContext scenarioContext)
        {
            _page = (MainPage)scenarioContext["MainPage"];
        }

        [Given(@"user opened language changing tab")]
        [When(@"user opens language changing tab")]
        public void OpenLanguageChangingTab()
        {
            MainPage page = (MainPage)_page;
            _page = page.MainPageTopBar.ClickLanguageSelectionButton();
        }

        [Given(@"user chose '(.*)' language")]
        [When(@"user chooses '(.*)' language")]
        public void ChangeLanguage(string language)
        {
            LanguageSelectionBar page = (LanguageSelectionBar)_page;
            _page = page.ChooseLanguage(language);
        }

        [Then(@"car rentals changed name should be '(.*)'")]
        public void ChangedNameShouldBe(string expectedText)
        {
            MainPage page = (MainPage)_page;
            string actualText = page.MainPageTopBar.GetCarRentalsButtonsText();
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
    }
}
