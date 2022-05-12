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
    public class PlaygroundAPIDeleteUserTests : BaseHttpClientTest
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
        public async Task DeleteUser_WhenIdIsNotAccessable_ShouldReturnAnouthorized()
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
            var result = await Client.Delete<ErrorMessage>("users/", idToCheck);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task DeleteUser_WhenIdIsAccessable_ShouldReturnUserInfo()
        {
            // Arrange
            var expectedResult = new SuccessMessage
            {
                Status = 200,
                Response = "user deleted",
            };

            // Act
            var result = await Client.Delete<SuccessMessage>("users/", _id);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
