namespace Pattern_Prototype.Utils
{
    internal static class RandomUtility
    {
        private static readonly Random _random = new Random();
        private static readonly Gender[] _genders = Enum.GetValues<Gender>().ToArray();

        public static int GetAge()
        {
            return _random.Next(100);
        }

        public static int GetAmountOfEggs()
        {
            return _random.Next(10000);
        }

        public static bool GetAlive()
        {
            return _random.Next(2) == 1;
        }

        public static Gender GetGender() 
        {
            return _genders[_random.Next(_genders.Length)];
        }

        public static TimeSpan GetGrowthPeriod()
        {
            return TimeSpan.FromDays(_random.Next(5, 40));
        }
    }
}
