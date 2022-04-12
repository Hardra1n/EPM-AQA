using QAAutomationLab.BusinessLayer.PageObjects.Stays.Components;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysAdPage : BasePage
    {
        public StaysAdHeaderContainer HeaderContainer => new();

        public StaysAdAvailableRoomContainer RoomContainer => new();
    }
}