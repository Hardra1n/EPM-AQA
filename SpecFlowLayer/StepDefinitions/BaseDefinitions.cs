using QAAutomationLab.CoreLayer.BasePage;
using TechTalk.SpecFlow;

namespace SpecFlowLayer.StepDefinitions
{
    [Binding]
    public class BaseDefinitions
    {
        private BasePage _page;

        public BaseDefinitions(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;
            Page = (BasePage)scenarioContext["Page"];
        }

        protected ScenarioContext ScenarioContext { get; set; }

        protected object Result { get; set; }

        protected BasePage Page
        {
            get
            {
                return _page;
            }

            set
            {
                _page = value;
                ScenarioContext["Page"] = _page;
            }
        }
    }
}
