using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Covid19.Components
{
    public class SherpaWidgetContainer : BasePage
    {
        private static By _containerLocator = By.Id("sherpa_widget_section_holder");

        public SherpaWidgetContainer()
            : base(_containerLocator) { }

        private BaseWebElement _widgetElement
            => containerElement.FindElement(By.Id("sherpa-widget-container"));

        public BaseWebElement GetSherpaWidget()
        {
            return _widgetElement;
        }
    }
}
