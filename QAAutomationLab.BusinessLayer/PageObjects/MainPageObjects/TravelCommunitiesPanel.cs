using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.TravelCommunities;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects
{
    public class TravelCommunitiesPanel : BasePage
    {
        private static readonly By _containerLocator = By.XPath("//div[contains(@data-et-click, \"communities\")]");

        private readonly BaseWebElement _travelTalkLink = new(By.XPath("//a[contains(@href, \"travel-discussion\")]"));

        private readonly BaseWebElement _moreCommunitiesLink = new(By.XPath("//a[contains(@href, \"communities/index\") and contains(@class, \"bui-card\")]"));

        public TravelCommunitiesPanel()
            : base(_containerLocator)
        {
        }

        public TravelCommunitiesPage GoToTravelTalk()
        {
            _travelTalkLink.Click();

            return new TravelCommunitiesPage();
        }

        public TravelCommunitiesPage GoToCommunities()
        {
            _moreCommunitiesLink.Click();

            return new TravelCommunitiesPage();
        }
    }
}
