using DelegatesEvents.ExtensionTask;
using DelegatesEvents.FileFinderTask;

namespace DelegatesEvents
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var tester = new GetMaxTester();
            tester.Run();

            Console.WriteLine("-------------------");

            var searchMaster = new SearchMaster();

            string downloadsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads");

            await searchMaster.SearchAsync(downloadsPath, "*");
        }
    }
}
