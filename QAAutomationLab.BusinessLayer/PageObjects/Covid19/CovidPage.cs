using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.Covid19.Components;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Covid19
{
    public class CovidPage : BasePage
    {
        public CovidPage()
            : base()
        {
            WidgetContainer = new SherpaWidgetContainer();
            RestrictionsContainer = new RestrictionsContainer();
        }

        public SherpaWidgetContainer WidgetContainer { get; private set; }

        public RestrictionsContainer RestrictionsContainer { get; private set; }
    }
}
