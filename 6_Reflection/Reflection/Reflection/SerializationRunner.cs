using Reflection.Serializers;
using Newtonsoft.Json;


namespace Reflection
{
    internal class SerializationRunner
    {
        public void RunMy()
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

            Console.WriteLine("My " + serializer.Serialize(f));
        }

        public void RunNewtonsoft() 
        {
            F f = new F()
            {
                i1 = 1,
                i2 = 2,
                i3 = 3,
                i4 = 4,
                i5 = 5,
            };

            JsonSerializer serializer = new JsonSerializer();
            StringWriter sw = new StringWriter();
            serializer.Serialize(sw, f);

            Console.WriteLine("Newtonsoft " + sw.ToString());

        }

        //Not used
        public void RunAnonymousTypes()
        {
            ISerializer serializer = new CsvSerializer();


            //1996 	Jeep 	Grand Cherokee 	MUST SELL! air, moon roof, loaded 	4799

            var smth1 = new
            {
                Year = 1996,
                Brand = "Jeep",
                Model = "Grand Cherokee",
                Note = "Grand Cherokee \tMUST SELL! air, moon roof, loaded",
                Price = 4799
            };

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
