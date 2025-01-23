namespace Parallel_Files_Reading
{
    internal class DirectoryProcessor
    {
        public static async Task ProcessAsync(string directory)
        {
            if (!Directory.Exists(directory))
            {
                await Console.Out.WriteLineAsync($"Directory {directory} not found. Canceling...");
                return;
            }
            var dirInfo = new DirectoryInfo(directory);
            var fileInfos = dirInfo.GetFiles();

            await Console.Out.WriteLineAsync($"Begin processing directory: '{directory}'");
            await Console.Out.WriteLineAsync($"Found '{fileInfos.Length}' files:"+ Environment.NewLine+
                string.Join(Environment.NewLine, fileInfos.Select(fi => fi.Name)));

            var tasks = fileInfos.Select(
                fi => Task.Run(() => FileProcessor.ProcessAsync(fi.FullName)));

            await Task.WhenAll(tasks);
        }
    }
}