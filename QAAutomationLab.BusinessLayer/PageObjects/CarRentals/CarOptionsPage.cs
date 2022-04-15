using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class CarOptionsPage : BasePage
    {
        public CarOptionsPage()
            : base()
        {
            CarOptionsMiddleBar = new CarOptionsMiddleBar();
        }

        public CarOptionsMiddleBar CarOptionsMiddleBar { get; private set; }
    }
}