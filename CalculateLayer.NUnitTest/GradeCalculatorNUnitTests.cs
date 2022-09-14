using NUnit.Framework;

namespace CalculateLayer.NUnitTest
{
    [TestFixture]
    public class GradeCalculatorNUnitTests
    {
        // Arrange
        private GradeCalculator _gradeCalculator;

        [SetUp]
        public void Initializer()
        {
            _gradeCalculator = new GradeCalculator();
        }

        [Test]
        [TestCase(95, 80, ExpectedResult = GradeType.A)]
        [TestCase(95, 65, ExpectedResult = GradeType.B)]
        [TestCase(80, 60, ExpectedResult = GradeType.B)]
        [TestCase(60, 90, ExpectedResult = GradeType.C)]
        [TestCase(60, 60, ExpectedResult = GradeType.C)]
        [TestCase(40, 90, ExpectedResult = GradeType.F)]
        [TestCase(30, 40, ExpectedResult = GradeType.F)]
        public GradeType CalculateGrade_InputScoreAndAttendancePercentage_OutputGrade(int score, int attendancePercentage)
        {
            var result = _gradeCalculator.CalculateGrade(score, attendancePercentage);

            return result;
        }
    }
}
