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

        [Test]
        public void GetFullName_InputEmptyLastName_OutputFullName()
        {
            // Act
            var fullName = _userManager.GetFullName("Mohammad", string.Empty);

            // Assert
            Assert.That(fullName, Is.Not.Null);
            Assert.IsFalse(string.IsNullOrEmpty(fullName));
        }

        [Test]
        public void GetFullName_InputEmptyFirstName_ThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                _userManager.GetFullName(string.Empty, "Mahdavi");
            });

            Assert.That("Name is required", Is.EqualTo(exception?.Message));

            Assert.That(() => _userManager.GetFullName(string.Empty, "Mahdavi"), 
                Throws.ArgumentException.With.Message.EqualTo("Name is required"));
        }

        [Test]
        public void UpdateUserDiscount_InputDiscountIntegerValue_UpdateDiscount()
        {
            _userManager.UpdateUserDiscount(20);

            Assert.That(_userManager.UserDiscount, Is.InRange(10, 30));
        }

        [Test]
        public void SayHello_InputEmptyName_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _userManager.SayHello(string.Empty);
            });

            Assert.That(() => _userManager.SayHello(string.Empty),
                Throws.ArgumentNullException);
        }

        [Test]
        public void CheckUserType_InputUserScoreGreaterThan100_OutputVipUserType()
        {
            _userManager.UserScore = 150;

            var result = _userManager.CheckUserType();

            Assert.That(result, Is.TypeOf<VipUser>());
        }

        [Test]
        public void CheckUserType_InputUserScoreLessThan100_OutputNormalUserType()
        {
            _userManager.UserScore = 40;

            var result = _userManager.CheckUserType();

            Assert.That(result, Is.TypeOf<NormalUser>());
        }
    }
}
