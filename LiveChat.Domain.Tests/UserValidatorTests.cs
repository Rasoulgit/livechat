using FluentAssertions;
using LiveChat.Domain.Chat.Concrete;
using NUnit.Framework;

namespace LiveChat.Domain.Tests
{
    [TestFixture]
    public class UserValidatorTests
    {
        private readonly UserValidator validator = new UserValidator();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Validate_WhenUsernameIsEmpty_ReturnError()
        {
            //Act

            var result = validator.Validate(string.Empty);

            //Assert

            result.Success.Should().BeFalse();
            result.Error.Should().Be("Username cannot be empty.");
        }
    }
}