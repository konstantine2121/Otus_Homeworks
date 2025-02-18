namespace Guess_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new GameControllerFactory();
            var game = factory.Create(new Range(1,100), 6);

            while(true)
            {
                game.Start();
                Console.WriteLine();
            }
        }
    }
}
