namespace Guess_Game
{
    internal interface IRandomGenerator
    {
        int Min { get; }

        int Max { get; }

        int Generate();
    }
}
