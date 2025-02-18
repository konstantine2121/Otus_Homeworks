using Reflection.Serializers;

namespace Reflection
{
    internal class SerializationRunner
    {
        public void Run()
        {
            ISerializer serializer = new CsvSerializer();

            F f = new F() 
            { 
                i1 = 1,
                i2 = 2,
                i3 = 3,
                i4 = 4,
                i5 = 5,
            };

            Console.WriteLine(serializer.Serialize(f));

            //1996 	Jeep 	Grand Cherokee 	MUST SELL! air, moon roof, loaded 	4799

            var smth1 = new { 
                Year = 1996, 
                Brand = "Jeep", 
                Model = "Grand Cherokee", 
                Note= "Grand Cherokee \tMUST SELL! air, moon roof, loaded", 
                Price = 4799 };

            Console.WriteLine(serializer.Serialize(smth1));

            var smth2 = new
            {
                Year = 1999,
                Brand = "Chevy",
                Model = "Venture \"Extended Edition\"",
                Note = "",
                Price = 4900
            };

            Console.WriteLine(serializer.Serialize(smth2));
        }
    }
}
