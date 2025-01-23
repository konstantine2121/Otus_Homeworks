namespace Parallel_Files_Reading
{
    internal class Task1
    {
        private readonly string _directory = Path.Combine("Files", "task_1");

        public async Task Run()
        {
            var filepath1 = Path.Combine(_directory, "text_1.txt");
            var filepath2 = Path.Combine(_directory, "text_2.txt");
            var filepath3 = Path.Combine(_directory, "text_3.txt");

            var tasks = new Task []
                { 
                    Task.Run(() => FileProcessor.ProcessAsync(filepath1)),
                    Task.Run(() => FileProcessor.ProcessAsync(filepath2)),
                    Task.Run(() => FileProcessor.ProcessAsync(filepath3))
            };

            await Task.WhenAll(tasks);
        }
    }
}