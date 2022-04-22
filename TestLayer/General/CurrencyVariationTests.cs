using System.Collections.Generic;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.General
{
    [TestFixture]
    public class CurrencyVariationTests:BaseTest
    {
        [Test]
        public void CurrencyVariationTest()
        {
            List<Currencies> currencies = CsvDeserializator.ReadCurrenciesFromCSV("Currencies.csv");

            var basepage = Utilities.RunBrowser(TestsSettings.MainPageUrl);

            foreach (var currency in currencies)
            {
                var page = basepage.MainPageTopBar
                    .ClickCurrencyVariationButton()
                    .ChooseCurrency(currency.Name)
                    .MainPageTopBar
                    .GoToCarRentals()
                    .CarRentalsSearchPanel
                    .EnterPickUpLocation("Berlin")
                    .ChooseFirstPickUpSuggestion("Berlin")
                    .ClickSearchButton()
                    .SearchResultsPanel;

                string text = page.GetFirstResultPriceText();

                basepage=page.GoToMainPage();

                Assert.IsTrue(text.Contains(currency.Value));
            }
        }
    }
}
