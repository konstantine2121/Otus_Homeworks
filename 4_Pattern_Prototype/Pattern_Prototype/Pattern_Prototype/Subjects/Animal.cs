namespace Pattern_Prototype.Subjects
{
    /// <summary>
    /// Является наследником живого <see cref="Creature">существа</see><br/>
    /// Добавляется свойство <see cref="Gender">пол</see> 
    /// (<see cref="Gender.Male">мужской</see>/<see cref="Gender.Female">женский</see>)
    /// </summary>
    public class Animal : Creature, IMyCloneable<Animal>
    {
        public Animal(bool alive, int age, Gender gender) : base(alive, age)
        {
            Gender = gender;
        }

        protected Animal(Animal creature) : base(creature)
        {
            Gender = creature.Gender;
        }

        public Gender Gender { get; }

        Animal IMyCloneable<Animal>.Clone()
        {
            return new Animal(this);
        }

        public override object Clone()
        {
            return new Animal(this);
        }
    }
}
