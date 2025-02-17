namespace Guess_Game
{
    public static class ComparisonResultExtensions
    {
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
