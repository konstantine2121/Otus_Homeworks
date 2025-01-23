using Multithreaded_Project.Calculators;

namespace Multithreaded_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int arrayLength1 = 100_000;
            const int arrayLength2 = 1_000_000;
            const int arrayLength3 = 10_000_000;

            var master = new CalculationMaster();
            var synchronousCalculator = new SynchronousCalculator();
            var linqParallelCalculator = new LinqParallelCalculator();
            var threadCalculator = new ThreadCalculator();

            var delimiter = "----------------------------------------";

            Console.WriteLine("Генерация исходных данных");

            var provider1 = new ArrayValuesProvider(arrayLength1);
            var provider2 = new ArrayValuesProvider(arrayLength2);
            var provider3 = new ArrayValuesProvider(arrayLength3);

            var list1 = provider1.Values;
            var list2 = provider2.Values;
            var list3 = provider3.Values;

            Console.WriteLine("Генерация завершена");

            Console.WriteLine(delimiter);
            
            master.Run(synchronousCalculator, list1, nameof(synchronousCalculator));
            master.Run(synchronousCalculator, list2, nameof(synchronousCalculator));
            master.Run(synchronousCalculator, list3, nameof(synchronousCalculator));
            master.AddEmptyRecord();
                        
            Console.WriteLine(delimiter);

            master.Run(threadCalculator, list1, nameof(threadCalculator));
            master.Run(threadCalculator, list2, nameof(threadCalculator));
            master.Run(threadCalculator, list3, nameof(threadCalculator));
            master.AddEmptyRecord();

            Console.WriteLine(delimiter);

            master.Run(linqParallelCalculator, list1, nameof(linqParallelCalculator));
            master.Run(linqParallelCalculator, list2, nameof(linqParallelCalculator));
            master.Run(linqParallelCalculator, list3, nameof(linqParallelCalculator));
            master.AddEmptyRecord();

            master.PrintResults();
        }
    }
}
