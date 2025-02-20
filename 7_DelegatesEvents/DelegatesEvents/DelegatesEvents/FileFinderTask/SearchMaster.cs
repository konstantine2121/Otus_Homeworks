namespace DelegatesEvents.FileFinderTask
{
    internal class SearchMaster
    {
        private readonly FileFinder _fileFinder;
        private readonly Dictionary<CancellationToken, CancellationTokenSource> _cancelationMap = new Dictionary<CancellationToken, CancellationTokenSource>();
        private readonly Trial _trial = new Trial();

        public SearchMaster() 
        {
            _fileFinder = new FileFinder();

            _fileFinder.FileFound += OnFileFound;
            _fileFinder.SearchCompleted += OnSearchCompleted;
            _fileFinder.ErrorHappens += OnErrorHappens;

            _trial.LimitReached += OnTrialLimitReached;
        }

        public async Task SearchAsync(string directory, string pattern)
        {
            _trial.ClearCounter();

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            _cancelationMap.Add(cancellationTokenSource.Token, cancellationTokenSource);

            await Task.Run(() => _fileFinder.SearchAsync(directory, pattern, cancellationTokenSource.Token));
        }

        public void Cancel()
        {
            foreach(var source in _cancelationMap.Values.ToArray())
            {
                source.Cancel();
            }
        }

        #region Event handlers

        private void OnErrorHappens(object? sender, Exception e)
        {
            Console.WriteLine("Error:" + e.Message);
        }

        private void OnFileFound(object? sender, FileArgs e)
        {
            Console.WriteLine("FileFound: " +e.FullName);
            _trial.IncrementCounter();
        }

        private void OnSearchCompleted(object? sender, CancellationToken e)
        {
            _cancelationMap.Remove(e);

            Console.WriteLine("Search completed");
        }

        private void OnTrialLimitReached(object? sender, EventArgs e)
        {
            Console.WriteLine($"Trial limit reached ({Trial.MaxFiles} files). Search canceled.");
            
            Cancel();
        }

        #endregion Event handlers


        #region Nested

        private class Trial
        {
            public const int MaxFiles = 50;

            private int _filesCounter = 0;

            public event EventHandler LimitReached;

            public void IncrementCounter()
            {
                Interlocked.Increment(ref _filesCounter);

                if (_filesCounter >= MaxFiles)
                {
                    LimitReached?.Invoke(this, EventArgs.Empty);
                }
            }

            public void ClearCounter()
            {
                _filesCounter = 0;                
            }
        }

        #endregion
    }
}
