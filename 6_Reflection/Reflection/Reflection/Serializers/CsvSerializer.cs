using System.Linq;
using System.Reflection;

namespace Reflection.Serializers
{
    public class CsvSerializer : ISerializer
    {
        public const string Separator = ",";

        /// <summary>
        /// двойная кавычка, запятая, точка с запятой, новая строка
        /// </summary>
        public static readonly IReadOnlySet<char> ReservedSymbols = new HashSet<char>()
        {
            '\"', ',', ';', '\n'
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

            var propertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            var propertyValues = propertyInfos
                .Select(x => x.GetValue(obj)?.ToString() ?? string.Empty)
                .Select(HandleReserved)
                .ToArray();

            var all = fieldValues.Concat(propertyValues);

            return string.Join(Separator, all);
        }

        /// <summary>
        ///  According to RFC 4180
        /// </summary>
        private static string HandleReserved(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            string result = value;
                        
            //Cимвол двойной кавычки в поле должен быть удвоен.
            result = result.Replace("\"", "\"\"");

            //Если поле содержит запятые, переносы строк, двойные кавычки, то это поле должно быть заключено в двойные кавычки.
            //Если этого не сделать, то данные невозможно будет корректно обработать
            if (result.Any(ReservedSymbols.Contains))
            {
                result = "\"" + result + "\"";
            }

            return result;
        }
    }
}
