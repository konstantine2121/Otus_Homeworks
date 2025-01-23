namespace Parallel_Files_Reading
{
    internal class Task2
    {
        private readonly string _directory = Path.Combine("Files", "task_2");

        public async Task Run()
        {
            await DirectoryProcessor.ProcessAsync(_directory);
        }
    }
}