using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.TravelCommunities
{
    public class NewPostForm : BasePage
    {
        private static readonly By _containerLocator = By.TagName("form");

        public NewPostForm()
            : base(_containerLocator) { }

        public bool IsExist()
        {
            return containerElement.Displayed;
        }
    }
}
