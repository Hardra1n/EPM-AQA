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
            throw new NotImplementedException();
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Close();
        }
    }
}
