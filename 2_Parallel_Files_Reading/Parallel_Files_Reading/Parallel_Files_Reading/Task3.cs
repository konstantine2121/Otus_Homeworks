using System.Diagnostics;

namespace Parallel_Files_Reading
{
    internal class Task3
    {
        private readonly string _directory = Path.Combine("Files", "task_3");

        public async Task Run()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var filepath1 = Path.Combine(_directory, "text_8.txt");

            await Task.Run(() => FileProcessor.ProcessAsync(filepath1));

            stopwatch.Stop();
            await Console.Out.WriteLineAsync($"Complete in '{stopwatch.ElapsedMilliseconds}' ms");
        }
    }
}