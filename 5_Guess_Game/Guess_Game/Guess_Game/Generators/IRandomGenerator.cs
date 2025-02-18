namespace Guess_Game.Generators
{
    internal interface IRandomGenerator
    {
        int Min { get; }

        int Max { get; }

        int Generate();
    }
}
