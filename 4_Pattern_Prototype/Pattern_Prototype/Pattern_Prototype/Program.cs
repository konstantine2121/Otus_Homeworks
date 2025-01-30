using Pattern_Prototype.Subjects;

namespace Pattern_Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var theria = new Theria(true, 10, Gender.Male, TimeSpan.FromSeconds(5));

            var clone = (theria as IMyCloneable<Theria>)?.Clone();

            Console.ReadLine();
        }
    }


}
