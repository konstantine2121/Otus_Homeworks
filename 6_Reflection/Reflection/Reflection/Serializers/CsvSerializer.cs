using System.Reflection;

namespace Reflection.Serializers
{
    internal class CsvSerializer : ISerializer
    {
        public const string Separator = ",";

        /// <summary>
        /// двойная кавычка, запятая, точка с запятой, новая строка
        /// </summary>
        public static readonly IReadOnlySet<string> ReservedChars = new HashSet<string>()
        {
            "\"", ",", ";", "\r\n"
        };

        public string Serialize(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var type = obj.GetType();

            if (type == typeof(string))
            {
                return (string)obj;
            }

            var fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            var fieldValues = fieldInfos
                .Select(x => x.GetValue(obj)?.ToString() ?? string.Empty)
                .Select(HandleReserved)
                .ToArray();

            return string.Join(Separator, fieldValues);
        }

        /// <summary>
        ///  According to RFC 4180
        /// </summary>
        private static string HandleReserved(string value)
        {
            string result = value;

            foreach (var r in ReservedChars)
            {
                if (r == "\"")
                {
                    //символ двойной кавычки в поле должен быть удвоен
                    result = result.Replace(r, "\"\"");
                }
                else
                {
                    //если поле содержит запятые, переносы строк, двойные кавычки, то это поле должно быть заключено в двойные кавычки.
                    //Если этого не сделать, то данные невозможно будет корректно обработать
                    result = result.Replace(r, $"\"{r}\"");
                }
            }

            return result;
        }
    }
}
