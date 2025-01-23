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


            var spaces = await SpaceCounter.CountAsync(filepath);


            lock (_outputLock)
            {
                ConsoleHelper.WriteLine($"{guid}  Result: '{spaces}' spaces.", color);                
            }
        }
    }
}