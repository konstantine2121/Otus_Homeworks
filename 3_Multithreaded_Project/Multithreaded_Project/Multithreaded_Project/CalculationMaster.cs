using System.Diagnostics;
using Multithreaded_Project.Calculators;

namespace Multithreaded_Project
{
    internal class CalculationMaster
    {
        public void Run(IArraySumCalculator calculator, IReadOnlyList<int> values, string calculatorName)
        {
            Console.WriteLine($"Начало вычислений '{calculatorName} ({values.Count})'");

            Stopwatch sw = Stopwatch.StartNew();
            var sum = calculator.Sum(values);
            sw.Stop();

            Console.WriteLine($"'{calculatorName} ({values.Count})' закончил за {sw.ElapsedMilliseconds} мс.");
            Console.WriteLine($"Сумма = {sum}");
            
            Console.WriteLine();
        }
    }
}
