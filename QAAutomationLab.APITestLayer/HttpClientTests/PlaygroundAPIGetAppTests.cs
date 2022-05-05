using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using QAAutomationLab.CoreLayer.APIElement;

namespace QAAutomationLab.APITestLayer.HttpClientTests
{
    [TestFixture]
    public class PlaygroundAPIGetAppTests : BaseHttpClientTest
    {
        private int _userId;

        private string _token;

        private int _appId;

        [OneTimeSetUp]
        public async Task OneTimeTestSetup()
        {
            // Arrange
            var sendData = new Credentials
            {
                Email = "new_message@fexbox.org",
                Password = "Abcd_123",
            };
            var appData = new AppElements
            {
                phone_number = "1234567",
                Email = "email@email.com",
                LinkedIn = "linkedin.com",
                Github = "github.com",
                HomePage = "www.homepage.com",
            };

            // Act
            await Client.Post<SuccessNewUser>("users", sendData);
            var result = await Client.Post<SuccessLogin>("login", sendData);

            _userId = result.Id;
            _token = result.Token;
            Client.AddHeader("Authorization", "Bearer " + _token);

            var appResult = await Client.Post<SuccessNewApp>("application", appData);
            _appId = appResult.applicant_id;
        }

        [Test]
        public async Task GetApp_WhenIdIsNotAccessable_ShouldReturnUnauthorized()
        {
            // Arrange
            var idToCheck = 1000;
            var expectedStatus = 401;

            // Act
            var result = await Client.Get<ErrorMessage>("application/" + idToCheck);

            // Assert
            result.Status.Should().Be(expectedStatus);
        }

        [Test]
        public async Task GetApp_WhenIdIsAccessable_ShouldReturnAppInfo()
        {
            // Arrange
            var expectedResult = new SuccessNewApp
            {
                phone_number = "1234567",
                Email = "email@email.com",
                LinkedIn = "linkedin.com",
                Github = "github.com",
                HomePage = "www.homepage.com",
                user_id = _userId,
            };

            // Act
            var result = await Client.Get<ErrorMessage>("application/" + _appId);

            // Assert
            result.Should().BeEquivalentTo(expectedResult, option => option.ExcludingMissingMembers());
        }
    }
}
