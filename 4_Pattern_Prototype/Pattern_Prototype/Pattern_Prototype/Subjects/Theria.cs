namespace Pattern_Prototype.Subjects
{
    /// <summary>
    /// Живородящие <br/>
    /// Является наследником <see cref="Animal">животного</see><br/>
    /// Добавляется свойство <see cref="GrowthPeriod">время созревания плода</see>
    /// </summary>
    public class Theria : Animal, IMyCloneable<Theria>, IEquatable<Theria>
    {
        #region Ctor

        public Theria(bool alive, int age, Gender gender, TimeSpan growthPeriod) : base(alive, age, gender)
        {
            GrowthPeriod = growthPeriod;
        }

        protected Theria(Theria creature) : base(creature)
        {
            GrowthPeriod = creature.GrowthPeriod;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Время созревания плода
        /// </summary>
        public TimeSpan GrowthPeriod { get; }

        #endregion

        #region Clone

        public override Theria CloneMe()
        {
            return new Theria(this);
        }

        public override object Clone()
        {
            return new Theria(this);
        }

        #endregion

        #region Equals

        public override bool Equals(object? obj)
        {
            return obj != null
                && obj is Theria theria
                && Equals(theria);
        }

        public bool Equals(Theria? other)
        {
            return other != null
                && Alive == other.Alive
                && Age == other.Age
                && Gender == other.Gender
                && GrowthPeriod == other.GrowthPeriod;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Alive, Age, Gender, GrowthPeriod);
        }

        #endregion
    }
}