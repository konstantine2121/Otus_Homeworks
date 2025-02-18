namespace Guess_Game
{
    class GameControllerFactory
    {
        public GameController Create(Range range, int attemptsToWin)
        {
            var generator = new RandomGenerator(range);
            var game = new Game(generator, attemptsToWin);

            return new GameController(game);
        }
    }
}
