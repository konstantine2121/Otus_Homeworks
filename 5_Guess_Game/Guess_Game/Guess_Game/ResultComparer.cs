namespace Guess_Game
{
    internal static class ResultComparer
    {
        public static ComparisonResult Compare(int input, int target)
        {
            return ComparisonResultExtensions.FromInt(input.CompareTo(target));
        }
    }
}
