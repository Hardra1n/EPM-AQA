using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttrationPage : BasePage
    {
        private readonly BaseWebElement _searchFieldElement = new(By.XPath("//input[@type=\"search\"]"));

        private readonly BaseWebElement _submitButton = new(By.XPath("//input[@type=\"search\"]"));

        private readonly BaseWebElement _topDestinationDubai = new(By.XPath("//a[@title=\"Dubai\"]"));

        private readonly BaseWebElement _asiaTab = new(By.XPath("//button[.=\"Asia\"]"));

        private readonly BaseWebElement _kyotoLink = new(By.XPath("//a[@title=\"Kyoto\"]"));

        public AttrationPage(IWebDriver driver) : base(driver)
        {
        }


    }
}
