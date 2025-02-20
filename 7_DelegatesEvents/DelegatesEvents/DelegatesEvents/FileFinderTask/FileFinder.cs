namespace DelegatesEvents.FileFinderTask
{
    internal class FileFinder
    {
        public event EventHandler<CancellationToken> SearchCompleted;
        public event EventHandler<FileArgs> FileFound;
        public event EventHandler<Exception> ErrorHappens;

        public async Task SearchAsync(string directoryPath, string searchPattern = "*", CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(directoryPath) || !Directory.Exists(directoryPath))
            {
                SearchCompleted?.Invoke(this, cancellationToken);
                return;
            }

            try
            {
                var dir = new DirectoryInfo(directoryPath);

                var files = dir.EnumerateFiles(searchPattern, SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }

                    FileFound?.Invoke(this, new FileArgs(file.FullName));
                }

            }
            catch (Exception ex)
            {
                ErrorHappens?.Invoke(this, ex);
            }
            finally
            {
                SearchCompleted?.Invoke(this, cancellationToken);
            }
        }
    }
}
