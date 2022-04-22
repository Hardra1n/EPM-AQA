using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using System.Collections.Generic;
using System.Linq;

namespace QAAutomationLab.BusinessLayer.PageObjects.Articles.Components
{
    public class ArticlesTopicsContainer : BasePage
    {
        private static By _containerLocator
            = By.XPath("//section[contains(@class, 'articles-nav__container')]");

        public ArticlesTopicsContainer()
            : base(_containerLocator) { }

        private List<BaseWebElement> _topicButtons
            => containerElement.FindElements(By.XPath(".//a")).ToList();

        public ArticlesMainPage GoToTopic(string name)
        {
            _topicButtons.First(elem => elem.Text.Contains(name)).Click();
            return new ArticlesMainPage();
        }

        public string[] GetTopicNames()
        {
            return _topicButtons.Select(elem => elem.Text).ToArray();
        }
    }
}
