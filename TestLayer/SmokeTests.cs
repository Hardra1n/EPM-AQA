using FluentAssertions;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Utilities;
using System.Threading.Tasks;

namespace TestLayer
{
    [TestFixture, Category("Smoke")]
    public class SmokeTests : BaseTest
    {
        [Test]
        public void GoToAttractions_WhenAllDataAreValid_ShouldReturnAttractionPage()
        {
            // Assert
            var mainPageUrl = TestsSettings.MainPageUrl;
            var attractionsPart = "attractions";

            // Act
            var mainPage = Utilities.RunBrowser(mainPageUrl);
            var attractionPage = mainPage.GoToAttractions();

            // Assert
            attractionPage.BaseUrl.Should().Contain(attractionsPart);
        }
    }
}
