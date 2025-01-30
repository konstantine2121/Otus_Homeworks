namespace Pattern_Prototype.Factories
{
    internal interface IFactory<T>
    {
        T Create();
    }
}
