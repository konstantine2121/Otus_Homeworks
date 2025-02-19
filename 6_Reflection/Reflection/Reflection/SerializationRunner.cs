using Reflection.Serializers;
using Newtonsoft.Json;
using Reflection.Deserializers;


namespace Reflection
{
    internal class SerializationRunner
    {
        public const int Iterations = 10_000;
        private readonly static string NewLine = Environment.NewLine;

        private readonly F f = new F()
        {
            i1 = 1,
            i2 = 2,
            i3 = 3,
            i4 = 4,
            i5 = 5,
        };

        public void Run()
        {
            PrintInfoMessage();
            RunMySerializer();
            RunNewtonsoft();
        }

        private void RunMySerializer()
        {
            ISerializer serializer = new CsvSerializer();
            IDeserializer<F> deserializer = new CsvDesializerF();
            Action action = null;

            #region Serialize

            string Serialize()
            {
                return serializer.Serialize(f);
            }

            action = () => Serialize();

            var serializationTicks = TimeMeasurmentUtility.MearureElapsedTicks(() => PerformMultipleTimes(action));

            #endregion

            #region Deserialize

            var serializedString = Serialize();

            F Deserialize()
            {
                if (deserializer.TryDeserialize(serializedString, out F result))
                {
                    return result;
                }

                return null;
            }

            action = () => Deserialize();

            var deserializationTicks = TimeMeasurmentUtility.MearureElapsedTicks(() => PerformMultipleTimes(action));

            #endregion

            PrintToolInfos("мой рефлекшен", serializationTicks, deserializationTicks);
        }

        private void RunNewtonsoft() 
        {
            JsonSerializer serializer = new JsonSerializer();
            Action action = null;

            #region Serialize

            string Serialize()
            {
               return JsonConvert.SerializeObject(f);
            }

            action = () => Serialize();

            var serializationTicks = TimeMeasurmentUtility.MearureElapsedTicks(() => PerformMultipleTimes(action));

            #endregion

            #region Deserialize

            var serializedString = Serialize();

            F? Deserialize()
            {
               return JsonConvert.DeserializeObject<F>(serializedString);
            }

            action = () => Deserialize();

            var deserializationTicks = TimeMeasurmentUtility.MearureElapsedTicks(() => PerformMultipleTimes(action));

            #endregion

            PrintToolInfos("стандартный механизм (NewtonsoftJson)", serializationTicks, deserializationTicks);
        }

        #region Utils

        private void PerformMultipleTimes(Action action)
        {
            for (int i = 0; i < Iterations; i++)
            {
                action();
            }
        }

        #endregion

        #region Messages

        private static void PrintInfoMessage()
        {
            Console.WriteLine(
                            "Сериализуемый класс: class F { int i1, i2, i3, i4, i5;}  " + NewLine +
                            $"код сериализации-десериализации: '{nameof(CsvSerializer)}',  '{nameof(CsvDesializerF)}'" + NewLine +
                            $"количество замеров: {Iterations} итераций  ");
        }

        private void PrintToolInfos(string toolName, long serializationTicks, long deserializationTicks)
        {
            Console.WriteLine(
@$"{toolName}:  
Время на сериализацию = {serializationTicks} тиков  
Время на десериализацию = {deserializationTicks} тиков");
        }

        #endregion
    }
}
