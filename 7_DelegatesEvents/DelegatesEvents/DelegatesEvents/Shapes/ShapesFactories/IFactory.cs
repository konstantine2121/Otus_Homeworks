namespace DelegatesEvents.Shapes.ShapesFactories
{
    internal interface IFactory<T>
    {
        T Create();
    }
}
