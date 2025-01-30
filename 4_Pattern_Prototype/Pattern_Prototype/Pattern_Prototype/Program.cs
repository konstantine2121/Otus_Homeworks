using Pattern_Prototype.Factories;
using Pattern_Prototype.Subjects;
using System.Runtime.InteropServices;

namespace Pattern_Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var bigFactory = new CombineCreatureFactory();

            var theria = new Theria(true, 10, Gender.Male, TimeSpan.FromSeconds(5));

            var clone = (theria as IMyCloneable<Theria>)?.Clone();

            var subjects = new List<Creature>();

            for (int i = 0; i < 10; i++) 
            {
                subjects.Add(bigFactory.CreateRandomSupportedType());
            }

            var subjectClones = subjects.Select(s => s.Clone()).ToArray();

            Console.WriteLine("Compare subjects and subjectClones");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(subjects[i].Equals(subjectClones[i]));
            }

            var animal = bigFactory.Create<Animal>();
            var animalClone = animal.Clone();

            Console.WriteLine(animal.Equals(animalClone));
        }
    }


}
