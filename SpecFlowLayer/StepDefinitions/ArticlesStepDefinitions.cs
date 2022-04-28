using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.PageObjects.Articles;
using QAAutomationLab.BusinessLayer.PageObjects.Stays.Components;
using QAAutomationLab.BusinessLayer.Utilities;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using TechTalk.SpecFlow;

namespace SpecFlowLayer.StepDefinitions
{
    [Binding]
    public sealed class ArticlesStepDefinitions
    {
        private BasePage _page;

        private List<BaseWebElement> _elements;

        private string[] _topicsNames;

        private string _title;

        [Given(@"Stay`s main context is opened")]
        public void GoToStaysPageMainContent()
        {
            _page = Utilities.RunBrowser("https://www.booking.com/index.en-gb.html").MainPageTopBar.GoToStays().MainContent;
        }

        [Given(@"Articles` page opened")]
        public void OpenArticlesPage()
        {
            StaysSearchingMainContainer page = (StaysSearchingMainContainer)_page;
            _page = page.GoToArticle().MainContent.GoToArticles();
        }

        [When(@"User get searching page`s articles")]
        public void GetArticles()
        {
            StaysSearchingMainContainer page = (StaysSearchingMainContainer)_page;
            _elements = page.GetArticles();
        }

        [When(@"User get topics` names")]
        public void GetTopicsNames()
        {
            ArticlesMainPage page = (ArticlesMainPage)_page;
            _topicsNames = page.TopicsContainer.GetTopicNames();
        }

        [When(@"User get first article`s title")]
        public void GetFirstArticleTitle()
        {
            ArticlesMainPage page = (ArticlesMainPage)_page;
            _title = page.ArticlesContainer.GetArticleCards().First().GetArticleTitle();
        }

        [Then(@"All links start with '(.*)' part")]
        public void AssertThatLinkStartWithPart(string correctPart)
        {
            Assert.Multiple(() =>
            {
                foreach (var link in _elements)
                {
                    string hrefAttribute = link.GetAttribute("href");
                    Assert.That(hrefAttribute, Does.StartWith(correctPart));
                }
            });
        }

        [Then(@"Articles` titles are not equal to each other")]
        public void AssertThatTitlesAreNotEqual()
        {
            ArticlesMainPage page = (ArticlesMainPage)_page;

            Assert.Multiple(() =>
            {
                for (int i = 1; i < _topicsNames.Length; i++)
                {
                    page = page.TopicsContainer.GoToTopic(_topicsNames[i]);
                    string newArticleTitle = page.ArticlesContainer
                                                 .GetArticleCards()
                                                 .First()
                                                 .GetArticleTitle();
                    Assert.That(_title, Does.Not.EqualTo(newArticleTitle));
                    _title = newArticleTitle;
                }
            });
        }
    }
}