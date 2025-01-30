using Pattern_Prototype.Subjects;

namespace Pattern_Prototype.Factories
{
    using static Pattern_Prototype.Utils.RandomUtility;

    internal class AnimalFactory : IFactory<Animal>
    {
        public Animal Create()
        {
            return new Animal(GetAlive(), GetAge(), GetGender());
        }
    }
}
