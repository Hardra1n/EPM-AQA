using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;

namespace QAAutomationLab.BusinessLayer.PageObjects.TravelCommunities
{
    public class CommunityFindList : BasePage
    {
        private static readonly By _containerLocator = By.XPath("//div[contains(@class, \"dropdown-list\")]");

        private readonly By _communitiesLocator = By.XPath("//a[not(@style=\"display: none;\") and @data-title]");

        private readonly By _hiddenCommunitiesLocator = By.XPath("//a[@style=\"display: none;\" and @data-title]");

        public CommunityFindList()
            : base(_containerLocator) { }

        public bool IsAnyCommunities()
        {
            return containerElement.FindElements(_communitiesLocator).Any();
        }

        public bool CheckIfAllResultsContain(string searchInput)
        {
            return containerElement.FindElements(_communitiesLocator).
                All(elem => elem.Text.Contains(searchInput));
        }

        public CommunityFindList WaitForFilterResults()
        {
            DriverInstance.WaitForElementToBeInvisable(_hiddenCommunitiesLocator);

            return this;
        }

        public TravelCommunitiesPage GoToFirstResult()
        {
            containerElement.FindElements(_communitiesLocator).Last().Click();

            return new TravelCommunitiesPage();
        }
    }
}
