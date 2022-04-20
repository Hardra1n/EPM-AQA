using QAAutomationLab.BusinessLayer.PageObjects.HelpCenter.Components;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.HelpCenter
{
    public class HelpCenterPage : BasePage
    {
        public HelpCenterPage()
            : base()
        {
            PopularQuestionsContainer = new PopularQuestionsContainer();
        }

        public PopularQuestionsContainer PopularQuestionsContainer { get; private set; }
    }
}
