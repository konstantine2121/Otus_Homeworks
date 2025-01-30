using Pattern_Prototype.Subjects;
using System.Diagnostics.CodeAnalysis;

namespace Pattern_Prototype.Сomparators
{
    internal class CreatureComparator : IEqualityComparer<Animal>
    {
        public bool Equals(Animal? x, Animal? y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            return x.Alive == y.Alive && x.Age == y.Age;
        }

        public int GetHashCode([DisallowNull] Animal obj)
        {
            return HashCode.Combine(obj.Alive, obj.Age);
        }
    }
}
