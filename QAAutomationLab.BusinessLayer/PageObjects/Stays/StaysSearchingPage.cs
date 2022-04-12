using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysSearchingPage : BasePage
    {
        public StaysSearchPanel SearchPanel => new StaysSearchPanel();
    }
}
