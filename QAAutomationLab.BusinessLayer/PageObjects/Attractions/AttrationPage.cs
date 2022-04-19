using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttrationPage : BasePage
    {
        public AttrationPage()
            : base()
        {
            AttractionsTopDestination = new AttractionsTopDestination();
            AttractionsSearchPanel = new AttractionsSearchPanel();
            AttractionsCityBar = new AttractionsCityBar();
            AttractionsFooter = new AttractionsFooter();
        }

        public AttractionsTopDestination AttractionsTopDestination { get; private set; }

        public AttractionsSearchPanel AttractionsSearchPanel { get; private set; }

        public AttractionsCityBar AttractionsCityBar { get; private set; }

        public AttractionsFooter AttractionsFooter { get; private set; }

        public string BaseUrl => DriverInstance.Url;
    }
}
