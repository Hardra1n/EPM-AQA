using QAAutomationLab.BusinessLayer.PageObjects.Stays.Components;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysAdPage : BasePage
    {
        public StaysAdPage()
            : base()
        {
            HeaderContainer = new StaysAdHeaderContainer();
            RoomContainer = new StaysAdAvailableRoomContainer();
        }

        public StaysAdHeaderContainer HeaderContainer { get; private set; }

        public StaysAdAvailableRoomContainer RoomContainer { get; private set; }
    }
}