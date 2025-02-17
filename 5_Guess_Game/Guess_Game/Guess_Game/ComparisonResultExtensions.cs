namespace Guess_Game
{
    public static class ComparisonResultExtensions
    {
        /// <param name="delta"> результат вызова <see cref="int.CompareTo(int)"/></param>
        public static ComparisonResult FromInt(int delta)
        {
            if (delta < 0)
                return ComparisonResult.Less;

            if (delta == 0)
                return ComparisonResult.Equal;

            return ComparisonResult.Greater;
        }
    }
}
