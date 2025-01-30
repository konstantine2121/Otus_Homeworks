namespace Pattern_Prototype.Subjects
{

    /// <summary>
    /// Яйцекладущие <br/>
    /// Является наследником <see cref="Animal">животного</see><br/>
    /// Добавляется свойство <see cref="AmountOfEggs">количество откладываемых яиц</see>
    /// </summary>
    public class Oviparous : Animal, IMyCloneable<Oviparous>, IEquatable<Oviparous>
    {
        #region Ctor

        public Oviparous(bool alive, int age, Gender gender, int amountOfEggs) : base(alive, age, gender)
        {
            AmountOfEggs = amountOfEggs;
        }

        protected Oviparous(Oviparous creature) : base(creature)
        {
            AmountOfEggs = creature.AmountOfEggs;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Количество откладываемых яиц
        /// </summary>
        public int AmountOfEggs { get; }

        #endregion

        #region Clone

        Oviparous IMyCloneable<Oviparous>.Clone()
        {
            return new Oviparous(this);
        }

        public override object Clone()
        {
            return new Oviparous(this);
        }

        #endregion

        #region Equals

        public override bool Equals(object? obj)
        {
            return obj != null
                && obj is Oviparous oviparous
                && Equals(oviparous);
        }

        public bool Equals(Oviparous? other)
        {
            return other != null
                && Alive == other.Alive
                && Age == other.Age
                && Gender == other.Gender
                && AmountOfEggs == other.AmountOfEggs;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Alive, Age, Gender, AmountOfEggs);
        }

        #endregion
    }
}