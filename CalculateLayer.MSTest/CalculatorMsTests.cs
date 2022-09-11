using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculateLayer.MSTest
{
    [TestClass]
    public class CalculatorMsTests
    {
        [TestMethod]
        public void AddNumbers_InputTwoInteger_OutputSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.AddNumbers(5, 10);

            // Assert
            Assert.AreEqual(15, result);
        }
    }
}
