using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.HelpCenter.Components
{
    public class PopularQuestionsContainer : BasePage
    {
        private static By _containerLocator = By.XPath("//div//nav");

        public PopularQuestionsContainer()
            : base(_containerLocator) { }

        private IEnumerable<BaseWebElement> _questionTopics
            => containerElement.FindElements(By.XPath("//li[@role='presentation']/button"));

        public IEnumerable<QuestionTopicContainer> GetQuestionTopics()
        {
            return _questionTopics.Select(button => new QuestionTopicContainer(button));
        }
    }
}
