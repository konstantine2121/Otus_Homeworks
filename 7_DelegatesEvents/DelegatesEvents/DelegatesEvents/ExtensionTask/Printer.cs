using DelegatesEvents.ExtensionTask.Shapes;

namespace DelegatesEvents.ExtensionTask
{
    internal static class Printer
    {
        public static void Print(Circle circle)
        {
            Console.WriteLine($"{nameof(Circle)}: " +
                $"{nameof(Circle.Radius)} = {circle.Radius}; " +
                $"{nameof(Circle.Square)} = {circle.Square}");
        }

        public static void Print(Triangle triangle)
        {
            Console.WriteLine($"{nameof(Triangle)}: " +
                $"{nameof(Triangle.A)} = {triangle.A};" +
                $"{nameof(Triangle.B)} = {triangle.B};" +
                $"{nameof(Triangle.C)} = {triangle.C};" +
                $"{nameof(Triangle.Square)} = {triangle.Square};");
        }
    }
}
