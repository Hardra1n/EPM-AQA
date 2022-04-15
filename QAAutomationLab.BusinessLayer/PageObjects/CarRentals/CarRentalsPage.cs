using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class CarRentalsPage : BasePage
    {
        public CarRentalsPage()
            : base()
        {
            CarRentalsSearchPanel = new CarRentalsSearchPanel();
        }

        public CarRentalsSearchPanel CarRentalsSearchPanel { get; private set; }
    }
}
