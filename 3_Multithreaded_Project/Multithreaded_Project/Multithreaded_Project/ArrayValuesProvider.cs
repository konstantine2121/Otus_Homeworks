using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Multithreaded_Project
{
    internal class ArrayValuesProvider
    {
        private static readonly Random _random = new Random();

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public ArrayValuesProvider(int count, int maxElementValue = 100)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            Values = GenerateValuesArray(count);
            MaxElementValue = maxElementValue;
            MaxElementValueExcluded = MaxElementValue + 1;
        }

        public IReadOnlyList<int> Values { get; } = new int[0];
        public int MaxElementValue { get; }

        private int MaxElementValueExcluded { get; }

        private int[] GenerateValuesArray(int count)
        {
            var result = new int[count];

            for (int i = 0; i < result.Length; i++) 
            {
                result[i] = _random.Next(MaxElementValueExcluded);
            }
            return result;
        }
    }
}
