namespace Parallel_Files_Reading
{
    internal static class ConsoleHelper
    {
        public static ConsoleColor[] ConsoleColors => Enum.GetValues<ConsoleColor>().ToArray();

        public static ConsoleColor GetRandomConsoleColor()
        {
            var colors = ConsoleColors.Except(
                new ConsoleColor[] { 
                    ConsoleColor.Black, 
                    ConsoleColor.White})
                .ToArray();

            return colors[Random.Shared.Next(colors.Length)];
        }

        public static void Write(
            string message, 
            ConsoleColor foregroundColor = ConsoleColor.White, 
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            var foregroundColorInfo = Console.ForegroundColor;
            var backgroundColorInfo = Console.BackgroundColor;

            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            Console.Write(message);

            Console.ForegroundColor = foregroundColorInfo;
            Console.BackgroundColor = backgroundColorInfo;
        }

        public static void WriteLine(
            string message,
            ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            var foregroundColorInfo = Console.ForegroundColor;
            var backgroundColorInfo = Console.BackgroundColor;

            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(message);

            Console.ForegroundColor = foregroundColorInfo;
            Console.BackgroundColor = backgroundColorInfo;
        }
    }
}