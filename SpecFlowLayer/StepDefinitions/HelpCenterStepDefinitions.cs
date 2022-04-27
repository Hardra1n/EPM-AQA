using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.PageObjects.HelpCenter;
using QAAutomationLab.BusinessLayer.PageObjects.HelpCenter.Components;
using QAAutomationLab.BusinessLayer.Utilities;
using QAAutomationLab.CoreLayer.BasePage;
using TechTalk.SpecFlow;

namespace SpecFlowLayer.StepDefinitions
{
    [Binding]
    public sealed class HelpCenterStepDefinitions
    {
        private HelpCenterPage _page;

        private IEnumerable<QuestionTopicContainer> _topics;

        [Given(@"I go to help center")]
        public void GoToHelpCenterPage()
        {
            _page = Utilities.RunBrowser("https://www.booking.com/index.en-gb.html").MainPageTopBar.GoToHelpCenter();
        }

        [When(@"I get question topics")]
        public void GetPopularTopics()
        {
            _topics = _page.PopularQuestionsContainer.GetQuestionTopics();
        }

        [Then(@"All buttons in topics are enabled and displayed")]
        public void AssertThatAllTopicsHasEnabledButtons()
        {
            Assert.Multiple(() =>
            {
                foreach (var topic in _topics)
                {
                    var questionButtons = topic.GetQuestionsButtons();
                    foreach (var button in questionButtons)
                    {
                        Assert.IsTrue(button.Displayed && button.Enabled);
                    }
                }
            });
        }
    }
}
