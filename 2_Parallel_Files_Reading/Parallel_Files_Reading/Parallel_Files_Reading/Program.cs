namespace Parallel_Files_Reading
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var task1 = new Task1();
            await task1.Run();

            await Console.Out.WriteLineAsync("--------------------------------------");
            
            var task2 = new Task2();
            await task2.Run();
      
            await Console.Out.WriteLineAsync("--------------------------------------");

            var task3 = new Task3();
            await task3.Run();

            await Console.Out.WriteLineAsync("--------------------------------------");

            await Console.Out.WriteLineAsync("Mission Complete!");
        }
    }
}
