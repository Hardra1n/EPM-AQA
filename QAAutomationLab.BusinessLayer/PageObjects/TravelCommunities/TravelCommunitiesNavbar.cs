using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.TravelCommunities
{
    public class TravelCommunitiesNavbar : BasePage
    {
        private static readonly By _containerLocator = By.ClassName("navbar__list");

        private readonly BaseWebElement _communityFindInput = new(By.XPath("//*[contains(@class, \"select-v2__dropdown\")]"));

        public TravelCommunitiesNavbar()
            : base(_containerLocator) { }

        private BaseWebElement Header => new(By.TagName("h1"));

        private CommunityFindList CommunityFindList => new CommunityFindList();

        public string GetHeaderText()
        {
            return Header.Text;
        }

        public CommunityFindList ShowList()
        {
            _communityFindInput.Click();

            return CommunityFindList;
        }

        public CommunityFindList ShowFilteredList(string searchInput)
        {
            _communityFindInput.Click();
            _communityFindInput.SendKeys(searchInput);

            return CommunityFindList;
        }
    }
}
