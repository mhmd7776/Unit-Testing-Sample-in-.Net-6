
namespace CalculateLayer
{
    public class FibonacciSequence
    {
        public List<int> GetFibonacci(int length)
        {
            var result = new List<int>() { 0, 1 };
            int a = 0, b = 1;

            if (length <= 1) return result;

            for (var i = 2; i < length; i++)
            {
                var sum = a + b;
                result.Add(sum);
                a = b;
                b = sum;
            }

            return result;
        }
    }
}
