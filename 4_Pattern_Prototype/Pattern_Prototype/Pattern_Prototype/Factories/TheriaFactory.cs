using Pattern_Prototype.Subjects;

namespace Pattern_Prototype.Factories
{
    using static Pattern_Prototype.Utils.RandomUtility;

    internal class TheriaFactory : IFactory<Theria>
    {
        public Theria Create()
        {
            return new Theria(GetAlive(), GetAge(), GetGender(), GetGrowthPeriod());
        }
    }
}
