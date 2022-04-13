using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttractionSinglePage : BasePage
    {
        public AttractionSinglePage()
            : base()
        {
            SinglePageForm = new SinglePageForm();
        }

        public string BaseUrl => DriverInstance.Url;

        public SinglePageForm SinglePageForm { get; private set; }
    }
}
