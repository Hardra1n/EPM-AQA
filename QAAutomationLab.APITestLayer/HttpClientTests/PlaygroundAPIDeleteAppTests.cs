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
    public class PlaygroundAPIDeleteAppTests : BaseHttpClientTest
    {
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

            _token = result.Token;
            Client.AddHeader("Authorization", "Bearer " + _token);

            var appResult = await Client.Post<SuccessNewApp>("application", appData);
            _appId = appResult.applicant_id;
        }

        [Test]
        public async Task DeleteApp_WhenIdIsNotAccessable_ShouldReturnUnauthorized()
        {
            // Arrange
            var idToCheck = 1;
            var expectedResult = new ErrorMessage
            {
                Status = 401,
                Error = new Dictionary<string, string>(),
            };
            expectedResult.Error.Add("unauthorized", "unauthorized");

            // Act
            var result = await Client.Delete<ErrorMessage>("application/", idToCheck);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task DeleteApp_WhenIdIsAccessable_ShouldReturnSuccessDelete()
        {
            // Arrange
            var expectedResult = new SuccessMessage
            {
                Status = 200,
                Response = "deleted",
            };

            // Act
            var result = await Client.Delete<SuccessMessage>("application/", _appId);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
