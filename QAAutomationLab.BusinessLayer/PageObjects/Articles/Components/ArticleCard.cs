using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Articles.Components
{
    public class ArticleCard : BasePage
    {
        public ArticleCard(BaseWebElement containerElement)
        {
            this.containerElement = containerElement;
        }

        private BaseWebElement _articleLink
            => containerElement.FindElement(By.XPath(".//a"));

        public string GetArticleTitle() => _articleLink.Text;

        public ArticlePage GoToArticle()
        {
            _articleLink.Click();
            return new ArticlePage();
        }
    }
}
