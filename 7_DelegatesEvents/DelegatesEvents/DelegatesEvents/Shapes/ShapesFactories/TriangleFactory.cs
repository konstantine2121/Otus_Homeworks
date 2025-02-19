namespace DelegatesEvents.Shapes.ShapesFactories
{
    internal class TriangleFactory : IFactory<Triangle>
    {
        public Triangle Create()
        {
            var a = GetSide();
            var b = GetSide();
            var c =  MathF.Max(
                Random.Shared.NextSingle() * (a+b),
                MathF.Abs(a-b)+0.3f);

            return new Triangle(a, b, c);
        }

        private static float GetSide()
        {
            return Random.Shared.NextSingle() * 100;
        }
    }
}
