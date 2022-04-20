using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Covid19.Components
{
    public class SherpaWidgetContainer : BasePage
    {
        private static By _containerLocator = By.Id("sherpa_widget_section_holder");

        public SherpaWidgetContainer()
            : base(_containerLocator) { }
    }
}
