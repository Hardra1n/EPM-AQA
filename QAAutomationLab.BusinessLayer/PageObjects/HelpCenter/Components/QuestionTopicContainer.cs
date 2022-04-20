using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.HelpCenter.Components
{
    public class QuestionTopicContainer : BasePage
    {
        private BaseWebElement _topicButton;

        public QuestionTopicContainer(BaseWebElement topicButton)
            : base()
        {
            _topicButton = topicButton;
        }

        private IEnumerable<BaseWebElement> _questionsButton
            => DriverInstance.FindElements(By.XPath("//div[@role='button']")).Select(elem => new BaseWebElement(elem));

        public IEnumerable<BaseWebElement> GetQuestionsButtons()
        {
            _topicButton.Click();
            return _questionsButton;
        }
    }
}
