using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace TestLayer
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void SetUp()
        {
            Driver = QAAutomationLab.CoreLayer.Driver.Driver.GetInstance();
        }

        [TearDown]
        public void TearDown()
        {
            QAAutomationLab.CoreLayer.Driver.Driver.Quit();
        }
    }
}
