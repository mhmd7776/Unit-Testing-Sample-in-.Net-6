namespace CalculateLayer
{
    public class Calculator
    {
        public int AddNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public bool IsEvenNumber(int number)
        {
            return number % 2 == 0;
        }

        public double Sin(double degree)
        {
            var radian = (Math.PI / 180) * degree;

            var result = Math.Sin(radian);

            return Math.Round(result, 1);
        }
    }
}
