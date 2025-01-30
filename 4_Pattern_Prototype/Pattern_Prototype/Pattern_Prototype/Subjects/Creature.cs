namespace Pattern_Prototype.Subjects
{
    /// <summary>
    /// Самый базовый класс для всех живых существ.<br/>
    /// Имеет <see cref="Alive">признак</see>  жив/мертв а также <see cref="Age">возраст</see>.
    /// </summary>
    public class Creature : IMyCloneable<Creature>, ICloneable
    {
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

        public int Age { get; }

        public bool Alive { get; }

        Creature IMyCloneable<Creature>.Clone()
        {
            return new Creature(this);
        }

        public virtual object Clone()
        {
            return new Creature(this);
        }
    }
}
