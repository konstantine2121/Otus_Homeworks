using Reflection.Serializers;

namespace Reflection.Deserializers
{
    internal class CsvDesializerF : IDeserializer<F>
    {
        public bool TryDeserialize(string csvString, out F obj)
        {
            obj = null;

            if (string.IsNullOrWhiteSpace(csvString))
            {
                return false;
            }

            try
            {
                var values = csvString
                    .Split(CsvSerializer.Separator)
                    .Select(int.Parse)
                    .ToArray();

                obj = new F()
                {
                    i1 = values[0],
                    i2 = values[1],
                    i3 = values[2],
                    i4 = values[3],
                    i5 = values[4],
                };
            }
            catch 
            {
                return false;
            }

            return true;
        }
    }
}
