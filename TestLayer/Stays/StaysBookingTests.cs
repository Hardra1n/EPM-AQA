using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Models;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.BusinessLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestLayer.Stays
{
    [TestFixture]
    [Category("All")]
    public class StaysBookingTests : BaseTest
    {
        private StaysBookingDetailsPage _page;

        [SetUp]
        public void SetUp()
        {
            _page = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                             .GoToStays()
                             .AddSearchingContext(StaysSearchingContext.GetDefaultContext())
                             .ClickSearchButton()
                             .ClickFirstAdNavigatingButton()
                             .AddOneRoomToBooking()
                             .ClickNavigatingToBookingButton();
        }

        [Test]
        [Category("Smoke")]
        public void CorrectNavigatingToFinalStep()
        {
            var resultPage = _page.AddBookingDetailsContext(StaysBookingDetailsContext.GetDefaultContext())
                                  .ClickConfirmButton();

            Assert.That(resultPage is StaysBookingFinalStepPage, Is.True);
        }
    }
}
