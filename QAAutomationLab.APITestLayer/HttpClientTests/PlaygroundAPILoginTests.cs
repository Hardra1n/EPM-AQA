﻿using System;
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
    public class PlaygroundAPILoginTests : BaseHttpClientTest
    {
        [SetUp]
        public async Task Setup()
        {
            // Arrange
            var sendData = new Credentials
            {
                Email = "new_message@fexbox.org",
                Password = "Abcd_123",
            };

            // Act
            await Client.Post<SuccessNewUser>("users", sendData);
        }

        [Test]
        public async Task Login_WhenThereIsNotEmail_ShouldReturnErrorWithNoEmail()
        {
            // Arrange
            var sendData = new Credentials
            {
                Password = "Abcd_123",
            };

            var expectedResult = new ErrorMessage
            {
                Status = 422,
                Error = new Dictionary<string, string>(),
            };
            expectedResult.Error.Add("required_email", "required email");

            // Act
            var result = await Client.Post<ErrorMessage>("login", sendData);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task Login_WhenThereIsNotPassword_ShouldReturnErrorWithNoPassword()
        {
            // Arrange
            var sendData = new Credentials
            {
                Email = "upeahe@fexbox.org",
            };

            var expectedResult = new ErrorMessage
            {
                Status = 422,
                Error = new Dictionary<string, string>(),
            };
            expectedResult.Error.Add("required_password", "required password");

            // Act
            var result = await Client.Post<ErrorMessage>("login", sendData);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task Login_WhenEmailIsWrong_ShouldReturnErrorWithWrongPassword()
        {
            // Arrange
            var sendData = new Credentials
            {
                Email = "upeahe.org",
                Password = "Abcd_123",
            };

            var expectedResult = new ErrorMessage
            {
                Status = 422,
                Error = new Dictionary<string, string>(),
            };
            expectedResult.Error.Add("invalid_email", "invalid email");

            // Act
            var result = await Client.Post<ErrorMessage>("login", sendData);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task Login_WhenAllDataAreValid_ShouldReturnOk()
        {
            // Arrange
            var sendData = new Credentials
            {
                Email = "new_message@fexbox.org",
                Password = "Abcd_123",
            };

            // Act
            var result = await Client.Post<SuccessLogin>("login", sendData);

            // Assert
            result.Should().NotBeNull();
            result.Email.Should().BeEquivalentTo(sendData.Email);
            result.Token.Should().NotBeNull();
        }
    }
}
