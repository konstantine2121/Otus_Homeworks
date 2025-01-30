namespace Pattern_Prototype.Subjects
{
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
