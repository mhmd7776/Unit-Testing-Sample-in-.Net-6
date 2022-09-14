using NUnit.Framework;

namespace CalculateLayer.NUnitTest
{
    [TestFixture]
    public class FibonacciSequenceNUnitTests
    {
        // Arrange
        private FibonacciSequence _fibonacciSequence;

        [SetUp]
        public void Initializer()
        {
            _fibonacciSequence = new FibonacciSequence();
        }

        [Test]
        public void GetFibonacci_InputLength_OutputFibonacciSequence()
        {
            var result = _fibonacciSequence.GetFibonacci(8);

            var expectedResult = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13 };

            Assert.That(result, Is.EquivalentTo(expectedResult));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Ordered);
            Assert.That(result.Count, Is.EqualTo(8));
        }
    }
}
