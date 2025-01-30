using Pattern_Prototype.Subjects;

namespace Pattern_Prototype.Factories
{
    using static Pattern_Prototype.Utils.RandomUtility;

    internal class OviparousFactory : IFactory<Oviparous>
    {
        public Oviparous Create()
        {
            return new Oviparous(GetAlive(), GetAge(), GetGender(), GetAmountOfEggs());
        }
    }
}
