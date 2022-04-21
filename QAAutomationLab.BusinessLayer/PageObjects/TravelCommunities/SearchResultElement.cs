using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.TravelCommunities
{
    public class SearchResultElement : BasePage
    {
        public SearchResultElement(BaseWebElement element)
            : base(element)
        { }

        private BaseWebElement Title => new(By.XPath("//h2"));

        public string GetTitle()
        {
            return Title.Text;
        }
    }
}
