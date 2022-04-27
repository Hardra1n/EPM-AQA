using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.TravelCommunities
{
    public class TravelCommunitiesAside : BasePage
    {
        private static readonly By _containerLocator = By.TagName("aside");

        private readonly BaseWebElement _askAQuestion = new(By.XPath("//*[contains(@href, \"type=question\") and contains(@class, \"new-post\")]"));

        private readonly BaseWebElement _giveATip = new(By.XPath("//*[contains(@href, \"type=tip\")]"));

        public TravelCommunitiesAside()
            : base(_containerLocator) { }

        private BaseWebElement SearchInput => new(By.XPath("//*[@name=\"query\"]"));

        private BaseWebElement SearchButton => new(By.XPath("//*[@type=\"submit\"]"));

        private BaseWebElement FilterButton => new(By.XPath("//*[@role=\"button\"]"));

        private BaseWebElement QuestionFilter => new(By.XPath("//a[@data-type=\"questions\"]"));

        public TravelCommunitiesPage SearchCommunity(string searchInput)
        {
            SearchInput.SendKeys(searchInput);
            SearchButton.Click();

            return new TravelCommunitiesPage();
        }

        public TravelCommunitiesPage FilterByQuestions()
        {
            FilterButton.Click();
            QuestionFilter.Click();

            return new TravelCommunitiesPage();
        }

        public NewPostPage GoToTip()
        {
            _giveATip.Click();

            return new NewPostPage();
        }

        public NewPostPage GoToQuestion()
        {
            _askAQuestion.Click();

            return new NewPostPage();
        }
    }
}
