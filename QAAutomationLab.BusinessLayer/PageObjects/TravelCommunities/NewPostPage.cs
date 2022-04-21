using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.TravelCommunities
{
    public class NewPostPage : BasePage
    {
        private readonly BaseWebElement _headText = new(By.TagName("h1"));

        public NewPostPage()
            : base()
        {
            NewPostForm = new NewPostForm();
        }

        public NewPostForm NewPostForm { get; private set; }

        public string GetHeadText()
        {
            return _headText.Text;
        }
    }
}
