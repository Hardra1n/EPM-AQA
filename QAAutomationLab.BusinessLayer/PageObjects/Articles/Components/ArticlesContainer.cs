using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Articles.Components
{
    public class ArticlesContainer : BasePage
    {
        private static By _containerLocator
            = By.XPath("//div[contains(@class, 'article-card')]//ancestor::section");

        public ArticlesContainer()
            : base(_containerLocator) { }

        private List<BaseWebElement> _articleCards
            => containerElement.FindElements(
                By.XPath("//div[contains(@class, 'articles_silo_redesign')]")).ToList();

        public List<ArticleCard> GetArticleCards()
        {
            return _articleCards.Select(elem => new ArticleCard(elem)).ToList();
        }
    }
}
