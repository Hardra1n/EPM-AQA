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
    public class PlaygrounAPIGetUserTests : BaseHttpClientTest
    {
        private int _id;

        private string _token;

        [OneTimeSetUp]
        public async Task OneTimeTestSetup()
        {
            // Arrange
            var sendData = new Credentials
            {
                Email = "new_message@fexbox.org",
                Password = "Abcd_123",
            };

            // Act
            await Client.Post<SuccessNewUser>("users", sendData);
            var result = await Client.Post<SuccessLogin>("login", sendData);

            _token = result.Token;
            _id = result.Id;
            Client.AddHeader("Authorization", "Bearer " + _token);
        }

        [Test]
        public async Task GetUser_WhenIdIsNotAccessable_ShouldReturnAnouthorized()
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
            var result = await Client.Get<ErrorMessage>("users/" + idToCheck);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task GetUser_WhenIdIsAccessable_ShouldReturnUserInfo()
        {
            // Arrange
            var expectedEmail = "new_message@fexbox.org";

            // Act
            var result = await Client.Get<SuccessNewUser>("users/" + _id);

            // Assert
            result.Should().NotBeNull();
            result.Email.Should().Be(expectedEmail);
            result.Id.Should().Be(_id);
        }
    }
}
