
namespace Multithreaded_Project.Calculators
{
    internal class LinqParallelCalculator : IArraySumCalculator
    {
        public long Sum(IReadOnlyList<int> values)
        {
            return values.AsParallel().Sum();
        }
    }
}
