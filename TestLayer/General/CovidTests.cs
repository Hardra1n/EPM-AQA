using NUnit.Framework;
using QAAutomationLab.BusinessLayer.PageObjects.Covid19;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.General
{
    [TestFixture]
    [Category("All")]
    public class CovidTests : BaseTest
    {
        private CovidPage _page;

        [SetUp]
        public void SetUp()
        {
            _page = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                             .MainPageTopBar
                             .GoToStays()
                             .MainContent
                             .GoToCovidPage();
        }
    }
}
