using NUnit.Framework;
using QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects;
using QAAutomationLab.CoreLayer.BasePage;
using TechTalk.SpecFlow;

namespace SpecFlowLayer.StepDefinitions.General
{
    [Binding]
    public class LanguageVariationDefinitions : BaseDefinitions
    {
        public LanguageVariationDefinitions(ScenarioContext scenarioContext)
            : base(scenarioContext) { }

        [Given(@"user opened language changing tab")]
        [When(@"user opens language changing tab")]
        public void OpenLanguageChangingTab()
        {
            var page = (MainPage)Page;
            Page = page.MainPageTopBar.ClickLanguageSelectionButton();
        }

        [Given(@"user chose '(.*)' language")]
        [When(@"user chooses '(.*)' language")]
        public void ChangeLanguage(string language)
        {
            var page = (LanguageSelectionBar)Page;
            Page = page.ChooseLanguage(language);
        }

        [Then(@"car rentals changed name should be '(.*)'")]
        public void ChangedNameShouldBe(string expectedText)
        {
            var page = (MainPage)Page;
            string actualText = page.MainPageTopBar.GetCarRentalsButtonsText();
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
    }
}
