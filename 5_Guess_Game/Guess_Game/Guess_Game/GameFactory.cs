namespace Guess_Game
{
    class GameFactory
    {
        public Game Create(Range range, int attemptsToWin)
        {
            return new Game(new RandomGenerator(range), attemptsToWin);
        }
    }
}
