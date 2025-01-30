using Pattern_Prototype.Subjects;

namespace Pattern_Prototype.Factories
{
    using static Pattern_Prototype.Utils.RandomUtility;

    internal class CreatureFactory : IFactory<Creature>
    {
        public Creature Create()
        {
            return new Creature(GetAlive(), GetAge());
        }
    }
}
