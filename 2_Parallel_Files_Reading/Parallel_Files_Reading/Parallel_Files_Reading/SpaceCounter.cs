namespace Parallel_Files_Reading
{
    internal class SpaceCounter
    {
        public static async Task<int> Count(string filepath)
        {
            const char space = ' ';
            int total = 0;

            if (string.IsNullOrWhiteSpace(filepath) || !File.Exists(filepath))
            {
                return 0;
            }

            try
            {
                var content = await File.ReadAllTextAsync(filepath);

                foreach (char character in content)
                {
                    if (character == space)
                    {
                        total++;
                    }
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error on file: '{filepath}'.{Environment.NewLine}Message: {ex.Message}");
            }

            return total;
        }
    }
}