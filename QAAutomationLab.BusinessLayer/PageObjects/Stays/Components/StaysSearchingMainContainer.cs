using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.Articles;
using QAAutomationLab.BusinessLayer.PageObjects.Covid19;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays.Components
{
    public class StaysSearchingMainContainer : BasePage
    {
        private static By _containerLocator = By.Id("bodyconstraint");

        public StaysSearchingMainContainer()
            : base(_containerLocator) { }

        private BaseWebElement _covidInfoButton
            => containerElement.FindElement(
                By.XPath("//a[contains(@aria-label, 'COVID')]"));

        private List<BaseWebElement> _articlesElements
            => containerElement.FindElements(
                By.XPath("//div[contains(@class, 'promote-articles')]/a")).ToList();

        public CovidPage GoToCovidPage()
        {
            Utilities.Utilities.SwitchToNewHandle(_covidInfoButton.Click);
            return new CovidPage();
        }

        public List<BaseWebElement> GetArticles()
        {
            return _articlesElements;
        }

        public ArticlePage GoToArticle(int id = 0)
        {
            _articlesElements[id].Click();
            return new ArticlePage();
        }
    }
}
