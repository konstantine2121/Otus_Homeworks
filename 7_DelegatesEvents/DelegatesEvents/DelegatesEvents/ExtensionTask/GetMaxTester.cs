using DelegatesEvents.ExtensionTask.Shapes;
using DelegatesEvents.ExtensionTask.Shapes.ShapesFactories;

namespace DelegatesEvents.ExtensionTask
{
    internal class GetMaxTester
    {
        public void Run()
        {
            RunCircles();
            Console.WriteLine();
            RunTriangles();
        }

        private void RunCircles()
        {
            var factory = new CircleFactory();
            var circles = new List<Circle>();

            for (int i = 0; i < 10; i++)
            {
                circles.Add(factory.Create());
            }

            Console.WriteLine("Круги");

            circles.ForEach(Printer.Print);


            Console.WriteLine("Круг c максимальным радиусом");
            var maxCircle = circles.GetMax(c => c.Radius);
            Printer.Print(maxCircle);
        }

        private void RunTriangles()
        {
            var factory = new TriangleFactory();
            var triangles = new List<Triangle>();

            for (int i = 0; i < 10; i++)
            {
                triangles.Add(factory.Create());
            }

            Console.WriteLine("Треугольники");

            triangles.ForEach(Printer.Print);


            Console.WriteLine("Треугольник c максимальной площадью");
            var maxTriangle = triangles.GetMax(t => t.Square);
            Printer.Print(maxTriangle);
        }
    }
}
