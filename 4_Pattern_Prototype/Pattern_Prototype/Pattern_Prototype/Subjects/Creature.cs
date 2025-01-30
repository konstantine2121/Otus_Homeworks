namespace Pattern_Prototype.Subjects
{
    /// <summary>
    /// Самый базовый класс для всех живых существ.<br/>
    /// Имеет <see cref="Alive">признак</see>  жив/мертв а также <see cref="Age">возраст</see>.
    /// </summary>
    public class Creature : IMyCloneable<Creature>, ICloneable, IEquatable<Creature>
    {
        #region Ctor

        public Creature(bool alive, int age)
        {
            Alive = alive;
            Age = age;
        }

        protected Creature(Creature creature)
        {
            Alive = creature.Alive;
            Age = creature.Age;
        }

        #endregion

        #region Properties
        
        public int Age { get; }

        public bool Alive { get; }

        #endregion

        #region Clone

        Creature IMyCloneable<Creature>.Clone()
        {
            return new Creature(this);
        }

        public virtual object Clone()
        {
            return new Creature(this);
        }

        #endregion

        #region Equals

        public override bool Equals(object? obj)
        {
            return obj != null
                && obj is Creature creature
                && Equals(creature);
        }

        public bool Equals(Creature? other)
        {
            return other != null
                && Alive == other.Alive
                && Age == other.Age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Alive, Age);
        }

        #endregion
    }
}
