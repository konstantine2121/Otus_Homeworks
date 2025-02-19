
namespace DelegatesEvents
{
    internal static class EnumerableExtensions
    {
        public static T? GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) 
            where T : class
        {
            return collection != null && collection.Any() 
                ? collection.MaxBy(convertToNumber)
                : default(T);
        }
    }
}
