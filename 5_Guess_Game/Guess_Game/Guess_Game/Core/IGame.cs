namespace Guess_Game.Core
{
    internal interface IGame : IDisposable
    {
        int AttemptsToWin { get; }

        int AttemptCounter { get; }

        int NumberToGuess { get; }

        int MinNumber { get; }

        int MaxNumber { get; }

        event EventHandler NewGameStarted;
        event EventHandler<bool> GameFinished;
        event EventHandler<int> TurnStarted;
        event EventHandler<ComparisonResult> TurnFinished;

        void StartNewGame();
    }
}
