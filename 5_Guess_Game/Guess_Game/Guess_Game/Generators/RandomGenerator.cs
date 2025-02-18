namespace Guess_Game.Generators
{
    class RandomGenerator : IRandomGenerator
    {
        private readonly Random _random = new Random();

        public RandomGenerator(Range range)
        {

            int start = range.Start.Value;
            int end = range.End.Value;

            if (start > end || start == end)
            {
                throw new ArgumentException(nameof(range));
            }

            Min = start;
            Max = end;
        }

        public int Min { get; }
        public int Max { get; }

        public int Generate()
        {
            return _random.Next(Min, Max + 1);
        }
    }
}
