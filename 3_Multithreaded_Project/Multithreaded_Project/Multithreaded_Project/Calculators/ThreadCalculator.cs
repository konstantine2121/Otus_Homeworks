
namespace Multithreaded_Project.Calculators
{
    internal class ThreadCalculator : IArraySumCalculator
    {
        public long Sum(IReadOnlyList<int> values)
        {
            const int sliceSize = 1000;
            const int numberOfWorkers = 10;

            int beginIndex = 0;

            Stack<long> results = new Stack<long>();
            Stack<Thread> workers = new Stack<Thread>();

            for(int i= 0; i < numberOfWorkers; i++)
            {
                Thread thread = new Thread(Work);
                thread.IsBackground = true;
                
                workers.Push(thread);
                thread.Start();
            }

            foreach (var thread in workers)
            {
                thread.Join();
            }

            return results.Sum();

            void Work()
            {
                while (true)
                {
                    int index = 0;
                    int end = 0;

                    lock (workers)
                    {
                        index = beginIndex;
                        beginIndex += sliceSize;
                    }

                    end = Math.Min(index + sliceSize, values.Count);

                    if (index >= values.Count)
                    {
                        break;
                    }

                    long result = 0;

                    for(int i = index; i < end; i++)
                    {
                        result += values[i];
                    }

                    lock (results)
                    {
                        results.Push(result);
                    }
                }
            }
        }

    }
}
