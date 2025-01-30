namespace Pattern_Prototype.Subjects
{
    /// <summary>
    /// Является наследником живого <see cref="Creature">существа</see><br/>
    /// Добавляется свойство <see cref="Gender">пол</see> 
    /// (<see cref="Gender.Male">мужской</see>/<see cref="Gender.Female">женский</see>)
    /// </summary>
    public class Animal : Creature, IMyCloneable<Animal>, IEquatable<Animal>
    {
        #region Ctor
        
        public Animal(bool alive, int age, Gender gender) : base(alive, age)
        {
            Gender = gender;
        }

        protected Animal(Animal creature) : base(creature)
        {
            Gender = creature.Gender;
        }

        #endregion Ctor

        #region Properties

        public Gender Gender { get; }

        #endregion Properties

        #region Clone

        public override Animal CloneMe()
        {
            return new Animal(this);
        }

        public override object Clone()
        {
            return new Animal(this);
        }

        #endregion

        #region Equals

        public override bool Equals(object? obj)
        {
            return obj != null 
                && obj is Animal animal 
                && Equals(animal);
        }

        public bool Equals(Animal? other)
        {
            return other != null
                && Alive == other.Alive
                && Age == other.Age
                && Gender == other.Gender;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Alive, Age, Gender);
        }

        #endregion
    }
}
