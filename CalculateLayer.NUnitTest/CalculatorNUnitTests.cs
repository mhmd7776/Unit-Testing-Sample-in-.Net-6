using NUnit.Framework;

namespace CalculateLayer.NUnitTest
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInteger_OutputSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.AddNumbers(5, 10);

            // Assert
            Assert.AreEqual(15, result);
        }

        [Test]
        public void IsEvenNumber_InputEvenNumber_OutputTrue()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.IsEvenNumber(12);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(17)]
        [TestCase(13)]
        public void IsEvenNumber_InputOddNumber_OutputFalse(int number)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.IsEvenNumber(number);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase(17, ExpectedResult = false)]
        [TestCase(14, ExpectedResult = true)]
        public bool IsEvenNumber_InputNumber_OutputFalseIfOddElseTrue(int number)
        {
            var calculator = new Calculator();

            var result = calculator.IsEvenNumber(number);

            return result;
        }

        [Test]
        [TestCase(30, ExpectedResult = 0.5)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(270, ExpectedResult = -1)]
        public double Sin_InputAngleInDegree_OutputSin(double degree)
        {
            var calculator = new Calculator();

            var result = calculator.Sin(degree);

            return result;
        }
    }
}
