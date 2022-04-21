using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.General
{
    [TestFixture]
    [Category("All")]
    public class ArticlesTests : BaseTest
    {
        [Test]
        public void ArticlesOnMainPageHasCorrectLinks()
        {
            string correctStartingSubstring
                = "https://www.booking.com/articles/";
            var page = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                .MainPageTopBar
                .GoToStays()
                .MainContent;

            var links = page.GetArticles();

            Assert.Multiple(() =>
            {
                foreach (var link in links)
                {
                    string hrefAttribute = link.GetAttribute("href");
                    Assert.That(hrefAttribute, Does.StartWith(correctStartingSubstring));
                }
            });
        }
    }
}
