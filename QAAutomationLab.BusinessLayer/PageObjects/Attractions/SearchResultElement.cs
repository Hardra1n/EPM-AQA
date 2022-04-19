using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class SearchResultElement : BasePage
    {
        public SearchResultElement(BaseWebElement element)
            : base(element)
        { }

        private BaseWebElement Title => new(By.XPath("//h4"));

        public string GetTitle()
        {
            return Title.Text;
        }
    }
}
