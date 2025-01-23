using Multithreaded_Project.Calculators;
using System.Diagnostics;

namespace Multithreaded_Project
{
    internal class CalculationMaster
    {
        private readonly List<RunRecord> _records = new List<RunRecord>();

        public void Run(IArraySumCalculator calculator, IReadOnlyList<int> values, string calculatorName)
        {
            Console.WriteLine($"Начало вычислений '{calculatorName} ({values.Count})'");

            Stopwatch sw = Stopwatch.StartNew();
            var sum = calculator.Sum(values);
            sw.Stop();
            var elapsed = sw.ElapsedTicks;

            Console.WriteLine($"'{calculatorName} ({values.Count})' закончил за {elapsed} тиков.");
            Console.WriteLine($"Сумма = {sum}");

            Console.WriteLine();
            _records.Add(new RunRecord(calculatorName, values.Count, elapsed));
        }

        public void AddEmptyRecord()
        {
            _records.Add(RunRecord.CreateEmpty());
        }

        public void PrintResults()
        {
            ResultPrinter.PrintResults(_records);
        }

        #region Nested

        private class RunRecord
        {
            public RunRecord(string calculatorName, int valusCount, long elapsed)
            {
                CalculatorName = calculatorName;
                ValusCount = valusCount;
                Elapsed = elapsed;
            }

            private RunRecord()
            {
                IsEmpty = true;
            }

            public static RunRecord CreateEmpty()
            {
                return new RunRecord();
            }

            public string CalculatorName { get; }

            public int ValusCount { get; }

            public long Elapsed { get; }

            public bool IsEmpty { get; } = false;
        }

        private static class ResultPrinter
        {
            const string template = "| {0, -25}| {1, 12}| {2, 12}|";
            const string delimeter = "|--------------------------|-------------|-------------|";

            public static void PrintResults(IEnumerable<RunRecord> records)
            {
                Console.WriteLine(delimeter);
                Console.WriteLine(template, "Имя", "Размер", "Время(тики)");
                Console.WriteLine(delimeter);

                foreach (var record in records)
                {
                    if (record.IsEmpty)
                    {
                        Console.WriteLine(delimeter);
                    }
                    else
                    {
                        Console.WriteLine(template, record.CalculatorName, record.ValusCount, record.Elapsed);
                    }
                }
            }
        }

        #endregion Nested
    }
}
