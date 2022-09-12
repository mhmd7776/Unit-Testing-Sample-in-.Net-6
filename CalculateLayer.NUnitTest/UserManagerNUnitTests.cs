using NUnit.Framework;

namespace CalculateLayer.NUnitTest
{
    [TestFixture]
    public class UserManagerNUnitTests
    {
        // Arrange
        private UserManager _userManager;

        [SetUp]
        public void Initializer()
        {
            _userManager = new UserManager();
        }

        [Test]
        public void GetFullName_InputFirstAndLastName_OutputFullName()
        {
            // Act
            var fullName = _userManager.GetFullName("Mohammad", "Mahdavi");

            // Assert
            Assert.That(fullName, Is.EqualTo("Mohammad Mahdavi"));
            Assert.That(fullName, Does.Contain(" "));
            Assert.That(fullName, Does.StartWith("mohammad").IgnoreCase);
            Assert.That(fullName, Does.Match("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]"));
        }
    }
}
