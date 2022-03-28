using FluentAssertions;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer.Attractions
{
    [TestFixture, Category("All")]
    public class AttractionsMainPageTests : BaseTest
    {
        [Test]
        public void ChooseTopDestinations_ShouldRedirectToAttrPage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var burjHalifTitle = "Burj Khalifa Admission Tickets: Floors 124 and 125";
            var attractionPage = Utilities.RunBrowser(mainPageUrl).GoToAttractions();

            // Act
            var firstResultTitle = attractionPage.GoToDubai().ShowFirstResultTitle();

            // Assert
            firstResultTitle.Should().BeEquivalentTo(burjHalifTitle);
        }
    }
}
