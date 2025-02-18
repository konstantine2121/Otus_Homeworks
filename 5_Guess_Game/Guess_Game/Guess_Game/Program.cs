using Guess_Game.Factories;

namespace Guess_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new GameControllerFactory();
            var gameController = factory.Create(new Range(1,100), 6);

            while(true)
            {
                gameController.Start();
                Console.WriteLine();
            }
        }
    }
}
