using Guess_Game.Core;
using Guess_Game.Generators;

namespace Guess_Game.Factories
{
    class GameControllerFactory
    {
        public GameController Create(Range range, int attemptsToWin)
        {
            var generator = new RandomGenerator(range);
            var gameFactory = new GameFactory(generator, attemptsToWin);

            return new GameController(gameFactory);
        }
    }
}
