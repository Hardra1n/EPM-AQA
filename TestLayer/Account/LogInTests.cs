using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.Account
{
    [TestFixture]
    [Category("All")]
    public class LogInTests : BaseTest
    {
        [Test]
        public void EnterEmailAndSubmit_WhenEmailIsIncorrect_ShouldShowAlertMessage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var loginPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToLoginPage();

            var alertMessage = "Please check if the email address you've entered is correct.";

            // Act
            var form = loginPage.LoginForm.InputEmail("abcd@adbc.abcd").SubmitData();

            // Assert
            form.CheckIfAlertExist().Should().BeTrue();
            form.GetAlertMessage().Should().BeEquivalentTo(alertMessage);
        }

        [Test]
        public void EnterEmailAndSubmit_WhenEmailIsNotSet_ShouldShowAlertMessage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var loginPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToLoginPage();

            var alertMessage = "Please enter your email address";

            // Act
            var form = loginPage.LoginForm.InputEmail(string.Empty).SubmitData();

            // Assert
            form.CheckIfAlertExist().Should().BeTrue();
            form.GetAlertMessage().Should().BeEquivalentTo(alertMessage);
        }

        [Test]
        public void EnterPasswordAndSubmit_WhenPasswordIsNotSet_ShouldShowAlertMessage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var loginPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToLoginPage();

            var email = "wehhus@fexbox.org";
            var alertMessage = "Please enter your Booking.com password";

            // Act
            var form = loginPage.LoginForm.
                InputEmail(email).
                SubmitData().InputPassword(string.Empty).SubmitData();

            // Assert
            form.CheckIfAlertExist().Should().BeTrue();
            form.GetAlertMessage().Should().BeEquivalentTo(alertMessage);
        }

        [Test]
        public void EnterPasswordAndSubmit_WhenPasswordIsIncorrect_ShouldShowAlertMessage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var loginPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToLoginPage();

            var email = "wehhus@fexbox.org";
            var alertMessage = "The email and password combination you entered doesn't match";

            // Act
            var form = loginPage.LoginForm.
                InputEmail(email).
                SubmitData().InputPassword("Abcd_123").SubmitData();

            // Assert
            form.CheckIfAlertExist().Should().BeTrue();
            form.GetAlertMessage().Should().BeEquivalentTo(alertMessage);
        }

        [Test]
        public void GoToGetLinkForm_ShouldShowText()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var loginPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToLoginPage();

            var email = "wehhus@fexbox.org";
            var headText = "Check your inbox";

            // Act
            var form = loginPage.LoginForm.
                InputEmail(email).
                SubmitData().GoToGetLinkForm();

            // Assert
            form.GetHeadText().Should().BeEquivalentTo(headText);
        }

        [Test]
        public void ReturnToLogin_ShouldReturnToEmailInput()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var loginPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToLoginPage();

            var email = "wehhus@fexbox.org";
            var headText = "Sign in or create an account";

            // Act
            var form = loginPage.LoginForm.
                InputEmail(email).
                SubmitData().GoToGetLinkForm().ReturnToLogin();

            // Assert
            form.GetHeadText().Should().BeEquivalentTo(headText);
        }

        [Test]
        public void LogIn_ShouldReturnToMainPage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var loginPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToLoginPage();

            var email = "wehhus@fexbox.org";
            var password = "j_D6sE_5t+U_N3c";

            // Act
            var mainPage = loginPage.LoginForm.
                LogIn(email, password);

            // Assert
            mainPage.MainPageTopBar.IsPersonLoggedIn.Should().BeTrue();
        }

        [Test]
        public void LogOut_ShouldReturnToMainPage()
        {
            // Arrange
            var email = "wehhus@fexbox.org";
            var password = "j_D6sE_5t+U_N3c";

            var mainPageUrl = TestsSettings.MainPageUrl;
            var mainPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToLoginPage().LoginForm.
                LogIn(email, password);

            // Act
            mainPage = mainPage.MainPageTopBar.ShowAccountMenu().LogOut();

            // Assert
            mainPage.MainPageTopBar.IsPersonLoggedIn.Should().BeFalse();
        }
    }
}
