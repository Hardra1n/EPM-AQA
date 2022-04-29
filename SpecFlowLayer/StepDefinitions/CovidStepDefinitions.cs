using System.Collections.Generic;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.PageObjects.Covid19;
using QAAutomationLab.BusinessLayer.Utilities;
using QAAutomationLab.CoreLayer.WebElement;
using TechTalk.SpecFlow;

namespace SpecFlowLayer.StepDefinitions
{
    [Binding]
    public sealed class CovidStepDefinitions
    {
        private CovidPage _page;

        private IEnumerable<BaseWebElement> _elements;

        private BaseWebElement _element;

        private string _srcAttribute;

        [Given(@"Covid page is opened")]
        public void GoToCovidPage()
        {
            _page = Utilities.RunBrowser("https://www.booking.com/index.en-gb.html")
                             .MainPageTopBar
                             .GoToStays()
                             .MainContent
                             .GoToCovidPage();
        }

        [When(@"User gets country restrictions links")]
        public void GetRestrictionsLinks()
        {
            _elements = _page.RestrictionsContainer.OpenRestrictions()
                                                   .GetCountryLinks();
        }

        [When(@"User gets serpa widget")]
        public void GetSerpaWidget()
        {
            _element = _page.WidgetContainer.GetSherpaWidget();
        }

        [When(@"User gets source attribute")]
        public void GetSerpaSourceAttr()
        {
            _srcAttribute = _element.GetAttribute("src");
        }

        [Then(@"Each link should contain '(.*)' or '(.*)' href part")]
        public void AssertThatAllLinksContainParts(string firstPart, string secondPart)
        {
            Assert.Multiple(() =>
            {
                foreach (var link in _elements)
                {
                    var hrefAttribute = link.GetAttribute("href");
                    bool isValid = hrefAttribute.StartsWith(firstPart) || hrefAttribute.StartsWith(secondPart);
                    Assert.That(isValid, Is.True);
                }
            });
        }

        [Then(@"Source should start with '(.*)' part")]
        public void AssertThatSourceContainPart(string srcPart)
        {
            Assert.That(_srcAttribute, Does.StartWith(srcPart));
        }
    }
}