using Pattern_Prototype.Factories;
using Pattern_Prototype.Tests;

namespace Pattern_Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestFactory.Run();
            Test_ICloneable.Run();
            Test_IMyCloneable.Run();
        }
    }


}
