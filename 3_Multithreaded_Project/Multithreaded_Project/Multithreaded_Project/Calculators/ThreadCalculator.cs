
namespace Multithreaded_Project.Calculators
{
    internal class ThreadCalculator : IArraySumCalculator
    {
        public long Sum(IReadOnlyList<int> values)
        {
            var slices = Slice(values.ToArray());

            Dictionary<Thread, long> sliceMap  = new Dictionary<Thread, long>(slices.Count);

            foreach (var slice in slices) 
            {
                Thread thread = new Thread(new ParameterizedThreadStart((th) => 
                { 
                    sliceMap[(Thread)th] = slice.Select(v => (long)v).Sum();
                }));
                thread.IsBackground = true;
                
                sliceMap[thread] = 0;

                thread.Start(thread);
            }

            foreach (var thread in sliceMap.Keys)
            {
                thread.Join();
            }

            return sliceMap.Values.Sum();
        }

        private IReadOnlyList<int[]> Slice(int[] values) 
        {
            const int sliceSize = 1000;
            
            int lastSliceSize = values.Length % sliceSize;
            bool lastSliceLessThanOthers = lastSliceSize != 0;

            int amountOfSlices = values.Length / sliceSize + (lastSliceLessThanOthers ? 1 : 0);

            int lasts = lastSliceLessThanOthers ?
                (amountOfSlices - 1) * sliceSize + lastSliceSize:
                amountOfSlices * sliceSize;

            List <int[]> slices = new List<int[]>(amountOfSlices);
            
            for (int i = 0; i < amountOfSlices; i++) 
            {
                int sourceIndex = i * sliceSize;                
                int copyLength = Math.Min(sliceSize, lasts);
                var array = new int[copyLength];

                Array.Copy(values, sourceIndex, array, 0, copyLength);

                slices.Add(array);
                lasts -= sliceSize;
            }

            return slices;
        }
    }
}
