using Pattern_Prototype.Factories;
using Pattern_Prototype.Subjects;

namespace Pattern_Prototype.Tests
{
    using static Pattern_Prototype.Utils.Printer;

    /// <summary>
    /// Проверяем работу ICloneable
    /// </summary>
    internal static class Test_ICloneable
    {

        public static void Run()
        {
            var factory = new CombineCreatureFactory();
            Console.WriteLine("Проверяем работу ICloneable");
            Console.WriteLine();

            var creatures = factory.CreateCreaturesList(3);
            var animals = factory.CreateAnimalsList(3);
            var oviparous = factory.CreateOviparousList(3);
            var theria = factory.CreateTheriaList(3);

            var creaturesClones = creatures.Select(c => c.Clone()).ToList();
            var animalsClones = animals.Select(c => c.Clone()).ToList();
            var oviparousClones = oviparous.Select(c => c.Clone()).ToList();
            var theriaClones = theria.Select(c => c.Clone()).ToList();

            var results = new List<bool>();

            Console.WriteLine("Проверяем creatures");
            Console.WriteLine();
            PerformCheck(creatures, creaturesClones, results);

          
            Console.WriteLine("Проверяем animals");
            Console.WriteLine();
            PerformCheck(animals, animalsClones, results);
          
            Console.WriteLine("Проверяем oviparous");
            Console.WriteLine();
            PerformCheck(oviparous, oviparousClones, results);

            Console.WriteLine("Проверяем theria");
            Console.WriteLine();
            PerformCheck(theria, theriaClones, results);

            if (results.Any(r => r == false))
            {
                Console.WriteLine("Обнаружены ошибки клонирования");
            }
            else
            {
                Console.WriteLine("Ошибок нет");
            }

        }

        private static void PerformCheck<T>(List<T> creatures, List<object> creaturesClones, List<bool> results) where T : Creature
        {
            for (int i = 0; i < creatures.Count; i++)
            {
                var s1 = creatures[i];
                var s2 = creaturesClones[i];
                Print(s1);
                Print(s2 as T);

                var result = s1.Equals(s2);
                results.Add(result);

                Console.WriteLine($"Equals(object? obj) = {result}");
                Console.WriteLine("---------");
            }
        }
    }
}
