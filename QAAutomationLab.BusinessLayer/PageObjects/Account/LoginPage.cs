using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Account
{
    public class LoginPage : BasePage
    {
        public LoginPage()
            : base()
        {
            LoginForm = new LoginForm();
        }

        public string BaseUrl => DriverInstance.Url;

        public LoginForm LoginForm { get; private set; }
    }
}
