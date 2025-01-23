
namespace Multithreaded_Project.Calculators
{
    internal class LinqCalculator : IArraySumCalculator
    {
        public long Sum(IReadOnlyList<int> values)
        {
            return values.AsParallel().Sum();
        }
    }
}
