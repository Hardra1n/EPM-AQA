using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.LanguageVariationTests
{
    [TestFixture]
    public class LanguageVariationTests : BaseTest
    {
        [Test]
        [TestCase("Deutsch")]
        public void LanguageSelectionTest(string language)
        {
            var page = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                .MainPageTopBar;

            string defaultText = page.GetCarRentalsButtonsText();

            string changedText = page.ClickLanguageSelectionButton().ChooseLanguage(language).MainPageTopBar.GetCarRentalsButtonsText();

            Assert.IsFalse(defaultText == changedText);
        }
    }
}
