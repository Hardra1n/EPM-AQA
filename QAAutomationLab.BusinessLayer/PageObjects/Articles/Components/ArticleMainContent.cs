using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Articles.Components
{
    public class ArticleMainContent : BasePage
    {
        private static By _containerLocator
            = By.XPath("//div[contains(@class, 'trt_is_blog')]");

        public ArticleMainContent()
            : base(_containerLocator) { }

        private BaseWebElement _articlesMainPageButton
            => containerElement.FindElement(By.XPath(".//nav//a"));

        public ArticlesMainPage GoToArticles()
        {
            _articlesMainPageButton.Click();
            return new ArticlesMainPage();
        }
    }
}
