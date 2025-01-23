using System.Diagnostics;

namespace Parallel_Files_Reading
{
    internal static class FileProcessor
    {
        private readonly static object _outputLock = new object();

        public static async Task ProcessAsync(string filepath)
        {
            var guid = Guid.NewGuid();
            var color = ConsoleHelper.GetRandomConsoleColor();

            lock (_outputLock)
            {
                ConsoleHelper.WriteLine($"{guid}  Begin processing file '{filepath}'", color);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            var spaces = await SpaceCounter.CountAsync(filepath);

            stopwatch.Stop();

            lock (_outputLock)
            {
                ConsoleHelper.WriteLine($"{guid}  Result: '{spaces}' spaces. \t\tComplete in '{stopwatch.ElapsedMilliseconds}' ms", color);                
            }
        }
    }
}