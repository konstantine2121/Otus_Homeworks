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

        public void StartNewGame()
        {
            AttemptCounter = 0;
            bool win = false;
            NumberToGuess = _generator.Generate();

            PrintGameWelcomeMessage();

            for (int i = 0; i < AttemptsToWin; i++)
            {
                if (PerformTurn())
                {
                    win = true;
                    break;
                }
            }

            PrintEndgameMessage(win);
        }

        private void PrintGameWelcomeMessage()
        {
            Output.PrintMessage(ConsoleColor.Green, $"Игра началась. Доступно {AttemptsToWin} попыток");
        }

        private void PrintEndgameMessage(bool win)
        {
            Output.PrintWarning("");

            if (win)
            {
                Output.PrintInfo($"Победа! Вы отгадали число!");
            }
            else
            {
                Output.PrintError($"Поражение. Вы истратили все доступные попытки ({AttemptsToWin}).");
                Output.PrintWarning($"Загаданное число = {NumberToGuess}");
            }
        }

        #region SingleTurn

        private bool PerformTurn()
        {
            AttemptCounter++;

            PrintTurnWelcomeMessage();
            int number = ReadUserInput();
            var result = ResultComparer.Compare(number, NumberToGuess);
            PrintTurnResult(result);

            return result == ComparisonResult.Equal;
        }

        private void PrintTurnWelcomeMessage()
        {
            Output.PrintMessage(ConsoleColor.Gray, "Попытка # " + AttemptCounter);
        }

        private int ReadUserInput()
        {
            return Input.ReadInteger($"Введите число [{_generator.Min}, {_generator.Max}]: ");
        }

        private void PrintTurnResult(ComparisonResult result)
        {
            switch(result)
            {
                case ComparisonResult.Equal:
                    Output.PrintMessage(ConsoleColor.Cyan, "Вы угадали!");
                    break;
                case ComparisonResult.Less:
                    Output.PrintMessage(ConsoleColor.Blue, "меньше");
                    break;
                case ComparisonResult.Greater:
                    Output.PrintMessage(ConsoleColor.Red, "больше");
                    break;
            }
        }

        #endregion SingleTurn

        public void Dispose()
        {
            _generator = null;
        }
    }
}
