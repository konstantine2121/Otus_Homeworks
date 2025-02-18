using Guess_Game.Core;
using Guess_Game.Generators;

namespace Guess_Game.Factories
{
    internal class GameFactory : IGameFactory
    {
        private readonly IRandomGenerator _generator;
        private readonly int _attemptsToWin;

        public GameFactory(IRandomGenerator generator, int attemptsToWin)
        {
            _generator = generator;
            _attemptsToWin = attemptsToWin;
        }

        public Game Create(Func<int> readUserGuessFunc)
        {
            return new Game(_generator, _attemptsToWin, readUserGuessFunc);
        }
    }
}
