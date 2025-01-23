namespace Multithreaded_Project.Calculators
{
    internal class SynchronousCalculator : IArraySumCalculator
    {
        public long Sum(IReadOnlyList<int> values)
        {
            long sum = 0;

            foreach (var value in values)
            {
                sum += value;
            }

            return sum;
        }
    }
}
