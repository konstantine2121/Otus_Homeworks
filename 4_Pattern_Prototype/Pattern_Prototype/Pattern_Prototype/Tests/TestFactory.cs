
using Pattern_Prototype.Factories;

namespace Pattern_Prototype.Tests
{
    using static Pattern_Prototype.Utils.Printer;

    /// <summary>
    /// Смотрим, что все виды животных создаются нормально
    /// </summary>
    internal static class TestFactory
    {
        public static void Run()
        {
            var factory = new CombineCreatureFactory();
            Console.WriteLine("Смотрим, что все виды животных создаются нормально");
            Console.WriteLine();

            var creatures = factory.CreateCreaturesList();
            var animals = factory.CreateAnimalsList();
            var oviparous = factory.CreateOviparousList();
            var theria = factory.CreateTheriaList();

            creatures.ForEach(s => Print(s));
            animals.ForEach(s => Print(s));
            oviparous.ForEach(s => Print(s));
            theria.ForEach(s => Print(s));
        }       
    }
}
