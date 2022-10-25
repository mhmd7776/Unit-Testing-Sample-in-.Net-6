using Moq;
using NUnit.Framework;

namespace CalculateLayer.NUnitTest
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        // Arrange
        private BankAccount _bankAccount;
        private Mock<ILogger> _loggerMock;

        [SetUp]
        public void Initializer()
        {
            _loggerMock = new Mock<ILogger>();
            _bankAccount = new BankAccount(_loggerMock.Object);
        }

        [Test]
        public void Deposit_InputIntegerAmount_OutputBalance()
        {
            var result = _bankAccount.Deposit(100);

            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        [TestCase(-200)]
        [TestCase(0)]
        public void Deposit_InputNegativeAmountOrZero_ThrowArgumentOutOfRangeException(int amount)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _bankAccount.Deposit(amount);
            });
        }

        [Test]
        public void Withdrawal_InputIntegerAmount_OutputBalance()
        {
            var result = _bankAccount.Withdrawal(50);

            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        [TestCase(-200)]
        [TestCase(0)]
        public void Withdrawal_InputNegativeAmountOrZero_ThrowArgumentOutOfRangeException(int amount)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _bankAccount.Withdrawal(amount);
            });
        }

        [Test]
        public void Withdrawal_InputMoreThanBalance_ThrowArgumentException()
        {
            _loggerMock.Setup(s => s.LogNotEnoughBalanceInWithdrawal(It.IsAny<string>())).Returns(true);

            Assert.That(() => _bankAccount.Withdrawal(500),
                Throws.ArgumentException.With.Message.EqualTo("The account balance is insufficient."));
        }

        [Test]
        public void BankAccountLogAndReturnMessage_InputStringMessage_OutputMessage()
        {
            const string expectedMessage = "Hello world";

            _loggerMock.Setup(s => s.LogAndReturnMessage(It.IsAny<string>())).Returns((string text) => text);

            Assert.That(_loggerMock.Object.LogAndReturnMessage("Hello world"), Is.EqualTo(expectedMessage));
        }

        [Test]
        public void BankAccountSayThanksToCustomer_InputName_OutputTrue()
        {
            var expectedMessage = "Thanks Mohammad for choosing us.";

            _loggerMock.Setup(s => s.SayThanksToCustomer(It.IsAny<string>(), out expectedMessage)).Returns(true);

            Assert.IsTrue(_loggerMock.Object.SayThanksToCustomer("Mohammad", out var result));

            Assert.That(result, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void BankAccountLoggerProperties_SetProperties()
        {
            _loggerMock.Setup(s => s.LogType).Returns("Warning");

            // Change properties
            _loggerMock.SetupAllProperties();
            _loggerMock.Object.LogType = "Success";

            Assert.That(_loggerMock.Object.LogType, Is.EqualTo("Success"));
        }

        [Test]
        public void BankAccountGetName_InputName_OutputName()
        {
            var template = "Welcome, ";

            _loggerMock.Setup(s => s.GetName(It.IsAny<string>()))
                .Returns(true)
                .Callback((string name) => template += name);

            _loggerMock.Object.GetName("Mohammad");

            Assert.That(template, Is.EqualTo("Welcome, Mohammad"));
        }

        [Test]
        public void DepositMethod_CallAddLogAndSetLogTypeOnce()
        {
            _bankAccount.Deposit(200);

            // Verification
            _loggerMock.Verify(s => s.AddLog(It.IsAny<TransactionType>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            _loggerMock.VerifySet(s => s.LogType = "Success", Times.Once);
            _loggerMock.VerifyGet(s => s.LogType, Times.AtLeastOnce);
        }
    }
}
