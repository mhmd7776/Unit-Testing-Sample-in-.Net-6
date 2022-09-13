namespace CalculateLayer
{
    public class Calculator
    {
        public List<int> Numbers = new();

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

        public List<int> GetOddNumbers(int min, int max)
        {
            Numbers.Clear();

            for (var i = min; i <= max; i++)
            {
                if (i % 2 != 0)
                {
                    Numbers.Add(i);
                }
            }

            return Numbers;
        }
    }
}
