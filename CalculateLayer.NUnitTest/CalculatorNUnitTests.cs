using NUnit.Framework;

namespace CalculateLayer.NUnitTest
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        // Arrange
        private Calculator _calculator;

        [SetUp]
        public void Initializer()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void AddNumbers_InputTwoInteger_OutputSum()
        {
            // Act
            var result = _calculator.AddNumbers(5, 10);

            // Assert
            Assert.AreEqual(15, result);
        }

        [Test]
        public void IsEvenNumber_InputEvenNumber_OutputTrue()
        {
            // Act
            var result = _calculator.IsEvenNumber(12);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(17)]
        [TestCase(13)]
        public void IsEvenNumber_InputOddNumber_OutputFalse(int number)
        {
            // Act
            var result = _calculator.IsEvenNumber(number);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase(17, ExpectedResult = false)]
        [TestCase(14, ExpectedResult = true)]
        public bool IsEvenNumber_InputNumber_OutputFalseIfOddElseTrue(int number)
        {
            var result = _calculator.IsEvenNumber(number);

            return result;
        }

        [Test]
        [TestCase(30, ExpectedResult = 0.5)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(270, ExpectedResult = -1)]
        public double Sin_InputAngleInDegree_OutputSin(double degree)
        {
            var result = _calculator.Sin(degree);

            return result;
        }

        [Test]
        public void GetOddNumbers_InputMinAndMaxRange_OutputOddNumbersInRange()
        {
            var expectedNumbers = new List<int> { 1, 3, 5, 7, 9 };

            var result = _calculator.GetOddNumbers(1, 10);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EquivalentTo(expectedNumbers));
                Assert.That(result, Does.Contain(7));
                Assert.That(result, Has.No.Member(6));
                Assert.That(result, Is.Not.Empty);
                Assert.That(result.Count, Is.EqualTo(5));
                Assert.That(result, Is.Ordered.Ascending);
                Assert.That(result, Is.Unique);
            });
        }
    }
}
