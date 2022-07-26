﻿using System.Collections.Generic;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.General
{
    [TestFixture]
    public class LanguageVariationTests : BaseTest
    {
        [Test]
        public void LanguageSelectionTest()
        {
            List<Translations> translations = CsvDeserializator.ReadTranslationsFromCSV("Translations.csv");

            var page = Utilities.RunBrowser(TestsSettings.MainPageUrl);

            foreach (var translation in translations)
            {
                page = page.MainPageTopBar.ClickLanguageSelectionButton().ChooseLanguage(translation.Language);

                Assert.IsTrue(page.MainPageTopBar.GetCarRentalsButtonsText().Equals(translation.CarRentalsTranslation));
            }
        }
    }
}
