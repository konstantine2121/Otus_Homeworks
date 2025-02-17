namespace Guess_Game
{
    internal interface IGame : IDisposable
    {
        int AttemptsToWin { get; }

        int AttemptCounter { get; }

        int NumberToGuess { get; }

        void StartNewGame();
    }
}
