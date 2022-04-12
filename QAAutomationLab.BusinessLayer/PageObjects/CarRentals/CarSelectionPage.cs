using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class CarSelectionPage : BasePage
    {
        public CarSelectionPage()
            : base()
        {
            CarSelectionPageRightBar = new CarSelectionPageRightBar();
        }

        public CarSelectionPageRightBar CarSelectionPageRightBar { get; private set; }
    }
}
