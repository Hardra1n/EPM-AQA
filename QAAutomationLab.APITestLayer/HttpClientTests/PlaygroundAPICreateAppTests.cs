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
    public class PlaygroundAPICreateAppTests : BaseHttpClientTest
    {
        private int _id;

        private string _token;

        [SetUp]
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

            _id = result.Id;
            _token = result.Token;
            Client.AddHeader("Authorization", "Bearer " + _token);
        }

        [Test]
        public async Task CreateApp_WhenDataIsInvalid_ShouldReturnNoFields()
        {
            // Arrange
            var sendData = new Credentials
            {
                Email = "new_message@fexbox.org",
                Password = "Abcd_123",
            };

            var expectedResult = new ErrorMessage
            {
                Status = 422,
                Error = new Dictionary<string, string>(),
            };
            expectedResult.Error.Add("required_linkedin", "required linkedin");
            expectedResult.Error.Add("required_phone_number", "required phone number");

            // Act
            var result = await Client.Post<ErrorMessage>("application", sendData);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task CreateApp_WhenDataAreValid_ShouldReturnAppInfo()
        {
            // Arrange
            var sendData = new AppElements
            {
                PhoneNumber = "1234567",
                Email = "email@email.com",
                LinkedIn = "linkedin.com",
                Github = "github.com",
                HomePage = "www.homepage.com",
            };
            var expectedResult = new SuccessNewApp
            {
                PhoneNumber = "1234567",
                Email = "email@email.com",
                LinkedIn = "linkedin.com",
                Github = "github.com",
                HomePage = "www.homepage.com",
                UserId = _id,
            };

            // Act
            var result = await Client.Delete<SuccessMessage>("users/", _id);

            // Assert
            result.Should().BeEquivalentTo(expectedResult, options => options.ExcludingMissingMembers());
        }
    }
}
