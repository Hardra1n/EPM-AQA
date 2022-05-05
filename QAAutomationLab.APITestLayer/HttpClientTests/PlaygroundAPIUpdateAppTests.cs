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
    public class PlaygroundAPIUpdateAppTests : BaseHttpClientTest
    {
        private int _userId;

        private string _token;

        private int _appId;

        [OneTimeSetUp]
        public async Task Setup()
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
        public async Task UpdateApp_WhenIdIsNotAccessable_ShouldReturnUnauthorized()
        {
            // Arrange
            var idToCheck = 1000;
            var appData = new AppElements
            {
                phone_number = "1234567",
                Email = "email@email.com",
                LinkedIn = "linkedin.com",
                Github = "github.com",
                HomePage = "www.homepage.com",
            };
            var expectedStatus = 401;

            // Act
            var result = await Client.Put<ErrorMessage>("application/", idToCheck, appData);

            // Assert
            result.Status.Should().Be(expectedStatus);
        }

        [Test]
        public async Task UpdateApp_WhenDataIsNotFull_ShouldReturnNoFields()
        {
            // Arrange
            var appData = new AppElements
            {
                phone_number = "1111111",
                Email = "email@email.com",
                Github = "github.com",
                HomePage = "www.homepage.com",
            };
            var expectedResult = new ErrorMessage
            {
                Status = 422,
                Error = new Dictionary<string, string>(),
            };
            expectedResult.Error.Add("required_linkedin", "required linkedin");

            // Act
            var result = await Client.Put<ErrorMessage>("application/", _appId, appData);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task UpdateApp_WhenDataAreValid_ShouldReturnAppInfo()
        {
            // Arrange
            var appData = new AppElements
            {
                phone_number = "1000000",
                Email = "mail@email.com",
                LinkedIn = "linkedin.com",
                Github = "github.com",
                HomePage = "www.homepage.com",
            };
            var expectedResult = new SuccessNewApp
            {
                applicant_id = _appId,
                phone_number = "1000000",
                Email = "mail@email.com",
                LinkedIn = "linkedin.com",
                Github = "github.com",
                HomePage = "www.homepage.com",
                user_id = _userId,
            };

            // Act
            var result = await Client.Put<SuccessNewApp>("application/", _appId, appData);

            // Assert
            result.Should().BeEquivalentTo(expectedResult, option => option.Excluding(e => e.created_at).Excluding(e => e.updated_at));
        }
    }
}
