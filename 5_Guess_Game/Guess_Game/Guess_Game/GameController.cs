using Guess_Game.ConsoleUtils;

namespace Guess_Game
{
    internal class GameController
    {
        private readonly IGame _game;

        public GameController(IGame game) 
        {
            _game = game;

            _game.NewGameStarted += OnGameStarted;
            _game.GameFinished += OnGameFinished;
            _game.TurnStarted += OnTurnStarted;
            _game.TurnFinished += OnTurnFinished;
        }

        
        public void Start() 
        {
            _game.StartNewGame();
        }

        #region Event handlers

        private void OnGameFinished(object? sender, bool win)
        {
            PrintGameFinishedMessage(win);
        }

        private void OnGameStarted(object? sender, EventArgs e)
        {
            PrintGameWelcomeMessage();
        }

        private void OnTurnStarted(object? sender, int e)
        {
            PrintTurnWelcomeMessage();
        }

        private void OnTurnFinished(object? sender, ComparisonResult result)
        {
            PrintTurnResult(result);
        }

        #endregion

        #region Messages

        private void PrintGameWelcomeMessage()
        {
            Output.PrintMessage(ConsoleColor.Green, $"Игра началась. Доступно {_game.AttemptsToWin} попыток");
        }

        private void PrintGameFinishedMessage(bool win)
        {
            Output.PrintWarning("");

            if (win)
            {
                Output.PrintInfo($"Победа! Вы отгадали число!");
            }
            else
            {
                Output.PrintError($"Поражение. Вы истратили все доступные попытки ({_game.AttemptsToWin}).");
                Output.PrintWarning($"Загаданное число = {_game.NumberToGuess}");
            }
        }

        private void PrintTurnWelcomeMessage()
        {
            Output.PrintMessage(ConsoleColor.Gray, "Попытка # " + _game.AttemptCounter);
        }

        private void PrintTurnResult(ComparisonResult result)
        {
            switch (result)
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

        #endregion Messages
    }
}
