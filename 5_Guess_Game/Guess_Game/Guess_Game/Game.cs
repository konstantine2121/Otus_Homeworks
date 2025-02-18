using Guess_Game.ConsoleUtils;

namespace Guess_Game
{
    class Game : IGame
    {
        private IRandomGenerator _generator;

        public Game(IRandomGenerator valueGenerator, int attemptsToWin)
        {
            _generator = valueGenerator ?? throw new ArgumentNullException(nameof(valueGenerator));
            AttemptsToWin = attemptsToWin;
        }

        public int AttemptsToWin { get; }
        
        public int AttemptCounter { get; private set; } = 0;

        public int NumberToGuess { get; private set; }

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

        #region SingleTurn

        private bool PerformTurn()
        {
            AttemptCounter++;

            TurnStarted?.Invoke(this, AttemptCounter);
            
            int number = ReadUserInput();
            var result = ResultComparer.Compare(number, NumberToGuess);            
            TurnFinished?.Invoke(this, result);

            return result == ComparisonResult.Equal;
        }

        

        private int ReadUserInput()
        {
            return Input.ReadInteger($"Введите число [{_generator.Min}, {_generator.Max}]: ");
        }

       

        #endregion SingleTurn

        public void Dispose()
        {
            _generator = null;
        }
    }
}
