using Pattern_Prototype.Subjects;

namespace Pattern_Prototype.Utils
{
    internal static class Printer
    {
        public static void Print(Creature creature)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>()
            {
                [nameof(Creature.Alive)] = creature.Alive.ToString(),
                [nameof(Creature.Age)] = creature.Age.ToString()
            };

            string info = string.Join(";\t", keyValues.Select(kp => $"{kp.Key}-{kp.Value}"));

            Console.WriteLine($"{creature.GetClassName(), -10} {info}");
        }

        public static void Print(Animal animal)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>()
            {
                [nameof(Animal.Alive)] = animal.Alive.ToString(),
                [nameof(Animal.Age)] = animal.Age.ToString(),
                [nameof(Animal.Gender)] = animal.Gender.ToString(),
            };

            string info = string.Join(";\t", keyValues.Select(kp => $"{kp.Key}-{kp.Value}"));

            Console.WriteLine($"{animal.GetClassName(),-10} {info}");
        }

        public static void Print(Oviparous oviparous)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>()
            {
                [nameof(Oviparous.Alive)] = oviparous.Alive.ToString(),
                [nameof(Oviparous.Age)] = oviparous.Age.ToString(),
                [nameof(Oviparous.Gender)] = oviparous.Gender.ToString(),
                [nameof(Oviparous.AmountOfEggs)] = oviparous.AmountOfEggs.ToString(),
            };

            string info = string.Join(";\t", keyValues.Select(kp => $"{kp.Key}-{kp.Value}"));

            Console.WriteLine($"{oviparous.GetClassName(),-10} {info}");
        }

        public static void Print(Theria theria)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>()
            {
                [nameof(Theria.Alive)] = theria.Alive.ToString(),
                [nameof(Theria.Age)] = theria.Age.ToString(),
                [nameof(Theria.Gender)] = theria.Gender.ToString(),
                [nameof(Theria.GrowthPeriod)] = theria.GrowthPeriod.ToString()
            };

            string info = string.Join(";\t", keyValues.Select(kp => $"{kp.Key}-{kp.Value}"));

            Console.WriteLine($"{theria.GetClassName(),-10} {info}");
        }
    }

    public static class ObjectExtensions
    {
        public static string GetClassName<T>(this T obj)
        {
            return obj?.GetType().Name ?? "null";
        }
    }
}
