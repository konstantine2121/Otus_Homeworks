namespace DelegatesEvents.ExtensionTask.Shapes.ShapesFactories
{
    internal class CircleFactory : IFactory<Circle>
    {
        public Circle Create()
        {
            return new Circle(GetRaduis());
        }

        private static float GetRaduis()
        {
            return Random.Shared.NextSingle() * 100;
        }
    }
}
