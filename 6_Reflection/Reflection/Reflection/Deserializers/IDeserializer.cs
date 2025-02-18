namespace Reflection.Deserializers
{
    public interface IDeserializer<T>
    {
        bool TryDeserialize(string csvString, out T obj);
    }
}
