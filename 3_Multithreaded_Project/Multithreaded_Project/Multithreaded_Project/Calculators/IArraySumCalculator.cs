namespace Multithreaded_Project.Calculators
{
    internal interface IArraySumCalculator
    {
        long Sum(IReadOnlyList<int> values);
    }
}
