namespace DelegatesEvents.ExtensionTask.Shapes
{
    internal class Circle : Shape
    {
        public Circle(float radius)
        {
            Radius = radius;
        }

        public float Radius { get; }

        public override float Square
        {
            get
            {
                float S = (float)(Math.PI * Math.Pow(Radius, 2));

                return S;
            }
        }
    }
}
