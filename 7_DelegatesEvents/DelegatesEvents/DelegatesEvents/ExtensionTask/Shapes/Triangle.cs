namespace DelegatesEvents.ExtensionTask.Shapes
{
    internal class Triangle : Shape
    {
        public Triangle(float a, float b, float c)
        {
            A = a;
            B = b;
            C = c;
        }

        public float A { get; }
        public float B { get; }
        public float C { get; }

        public override float Square
        {
            get
            {
                //Формула Герона

                float p = (A + B + C) / 2;
                double S = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
                return (float)S;
            }
        }
    }
}
