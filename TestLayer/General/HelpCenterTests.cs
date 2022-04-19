using NUnit.Framework;
using QAAutomationLab.BusinessLayer.PageObjects.HelpCenter;
using QAAutomationLab.BusinessLayer.PageObjects.HelpCenter.Components;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.General
{
    [TestFixture]
    [Category("All")]
    public class HelpCenterTests : BaseTest
    {
        private HelpCenterPage _page;

        [SetUp]
        public void SetUp()
        {
            _page = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                .MainPageTopBar
                .GoToHelpCenter();
        }

        [Test]
        public void QuestionsNavigatingButtonsDisplayableAndEnabled()
        {
            var topics = _page.PopularQuestionsContainer.GetQuestionTopics();

            Assert.Multiple(() =>
            {
                foreach (var topic in topics)
                {
                    var questionButtons = topic.GetQuestionsButtons();
                    foreach (var button in questionButtons)
                    {
                        Assert.IsTrue(button.Displayed && button.Enabled);
                    }
                }
            });
        }
    }
}
