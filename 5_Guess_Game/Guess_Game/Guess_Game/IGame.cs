namespace Guess_Game
{
    internal interface IGame : IDisposable
    {
        int AttemptsToWin { get; }

        int AttemptCounter { get; }

        int NumberToGuess { get; }

        event EventHandler NewGameStarted;
        event EventHandler<bool> GameFinished;
        event EventHandler<int> TurnStarted;
        event EventHandler<ComparisonResult> TurnFinished;

        void StartNewGame();
    }
}
