using Reflection.Serializers;

namespace Reflection
{
    internal class SerializationRunner
    {
        public void Run()
        {
            F f = new F() 
            { 
                i1 = 1,
                i2 = 2,
                i3 = 3,
                i4 = 4,
                i5 = 5,
            };

            ISerializer serializer = new CsvSerializer();

            var result = serializer.Serialize(f);

            Console.WriteLine(result);
        }
    }
}
