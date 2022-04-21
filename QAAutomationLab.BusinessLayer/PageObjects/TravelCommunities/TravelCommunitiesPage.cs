using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.TravelCommunities
{
    public class TravelCommunitiesPage : BasePage
    {
        public TravelCommunitiesPage()
            : base()
        {
            TravelCommunitiesNavbar = new TravelCommunitiesNavbar();
            TravelCommunitiesAside = new TravelCommunitiesAside();
            TravelCommunityMainBar = new TravelCommunityMainBar();
        }

        public string BaseUrl => DriverInstance.Url;

        public TravelCommunitiesNavbar TravelCommunitiesNavbar { get; private set; }

        public TravelCommunitiesAside TravelCommunitiesAside { get; private set; }

        public TravelCommunityMainBar TravelCommunityMainBar { get; private set; }
    }
}
