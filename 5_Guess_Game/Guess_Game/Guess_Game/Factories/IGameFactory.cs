using Guess_Game.Core;

namespace Guess_Game.Factories
{
    internal interface IGameFactory
    {
        Game Create(Func<int> readUserGuessFunc);
    }
}