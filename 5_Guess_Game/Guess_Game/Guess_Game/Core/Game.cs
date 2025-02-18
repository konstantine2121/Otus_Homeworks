using Guess_Game.Generators;

namespace Guess_Game.Core
{
    class Game : IGame
    {
        private IRandomGenerator _generator;

        public Game(IRandomGenerator valueGenerator, int attemptsToWin, Func<int> readUserGuessFunc)
        {
            _generator = valueGenerator ?? throw new ArgumentNullException(nameof(valueGenerator));
            AttemptsToWin = attemptsToWin;
            ReadUserGuess = readUserGuessFunc ?? throw new ArgumentNullException(nameof(readUserGuessFunc));
        }

        public int AttemptsToWin { get; }

        public int AttemptCounter { get; private set; } = 0;

        public int NumberToGuess { get; private set; }

        public int MinNumber => _generator.Min;

        public int MaxNumber => _generator.Max;

        public Func<int> ReadUserGuess { get; }

        public event EventHandler NewGameStarted;
        public event EventHandler<bool> GameFinished;
        public event EventHandler<int> TurnStarted;
        public event EventHandler<ComparisonResult> TurnFinished;

        public void StartNewGame()
        {
            AttemptCounter = 0;
            bool win = false;
            NumberToGuess = _generator.Generate();

            NewGameStarted?.Invoke(this, EventArgs.Empty);

            for (int i = 0; i < AttemptsToWin; i++)
            {
                if (PerformTurn())
                {
                    win = true;
                    break;
                }
            }

            GameFinished?.Invoke(this, win);
        }

        private bool PerformTurn()
        {
            AttemptCounter++;

            TurnStarted?.Invoke(this, AttemptCounter);

            int number = ReadUserGuess();
            var result = ResultComparer.Compare(number, NumberToGuess);
            TurnFinished?.Invoke(this, result);

            return result == ComparisonResult.Equal;
        }

        public void Dispose()
        {
            _generator = null;
        }
    }
}
