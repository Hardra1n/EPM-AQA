using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class BookingPage : BasePage
    {
        public BookingPage()
            : base() { }

        public string BaseUrl => DriverInstance.Url;

        public BookingForm BookingForm => new BookingForm();
    }
}
