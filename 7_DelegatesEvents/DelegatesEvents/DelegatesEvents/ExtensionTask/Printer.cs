using DelegatesEvents.ExtensionTask.Shapes;

namespace DelegatesEvents.ExtensionTask
{
    internal static class Printer
    {
        public static void Print(Circle circle)
        {
            Console.WriteLine($"{nameof(Circle)}:\t\t" +
                $"{nameof(Circle.Radius)} = {circle.Radius};\t" +
                $"{nameof(Circle.Square)} = {circle.Square}");
        }

        public static void Print(Triangle triangle)
        {
            Console.WriteLine($"{nameof(Triangle)}:\t" +
                $"{nameof(Triangle.A)} = {triangle.A};\t" +
                $"{nameof(Triangle.B)} = {triangle.B};\t" +
                $"{nameof(Triangle.C)} = {triangle.C};\t" +
                $"{nameof(Triangle.Square)} = {triangle.Square}");
        }
    }
}
