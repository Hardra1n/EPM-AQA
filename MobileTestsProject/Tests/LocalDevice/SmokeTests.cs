using NUnit.Framework;

namespace MobileTestsProject.Tests.LocalDevice
{
    [TestFixture]
    public class SmokeTests : BaseTest
    {
        [Test]
        public void GoToAttractions_WhenAllDataAreValid_ShouldReturnAttractionPage()
        {
            // Act
            Driver.Navigate().GoToUrl("https://www.booking.com/index.en-gb.html");
        }
    }
}
