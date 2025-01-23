namespace Parallel_Files_Reading
{
    /// <summary>
    /// You can find Stopwatch in
    /// <see cref="FileProcessor.ProcessAsync(string)"/>
    /// </summary>
    internal class Task3
    {
        private readonly string _directory = Path.Combine("Files", "task_3");

        public async Task Run()
        {
            var filepath1 = Path.Combine(_directory, "text_8.txt");           

            await Task.Run(() => FileProcessor.ProcessAsync(filepath1));
        }
    }
}