using NUnit.Framework;
using QAAutomationLab.BusinessLayer.PageObjects.Articles;
using QAAutomationLab.BusinessLayer.Utilities;
using System.Linq;

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

        [Test]
        public void CorrectArticlesFiltering()
        {
            var page = GoToArticlesMainPage();

            string[] topics = page.TopicsContainer.GetTopicNames();
            string articleTitle = page.ArticlesContainer
                                      .GetArticleCards()
                                      .First()
                                      .GetArticleTitle();

            Assert.Multiple(() =>
            {
                for (int i = 1; i < topics.Length; i++)
                {
                    page = page.TopicsContainer.GoToTopic(topics[i]);
                    string newArticleTitle = page.ArticlesContainer
                                                 .GetArticleCards()
                                                 .First()
                                                 .GetArticleTitle();
                    Assert.That(articleTitle, Does.Not.EqualTo(newArticleTitle));
                    articleTitle = newArticleTitle;
                }
            });
        }

        private ArticlesMainPage GoToArticlesMainPage()
        {
            return Utilities.RunBrowser(TestsSettings.MainPageUrl)
                .MainPageTopBar
                .GoToStays()
                .MainContent
                .GoToArticle()
                .MainContent
                .GoToArticles();
        }
    }
}
