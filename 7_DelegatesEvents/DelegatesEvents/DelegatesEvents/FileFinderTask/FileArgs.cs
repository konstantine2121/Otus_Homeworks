namespace DelegatesEvents.FileFinderTask
{
    internal class FileArgs : EventArgs
    {
        public FileArgs(string fullName)
        {
            FullName = fullName;
        }

        public string FullName { get; }
    }
}
