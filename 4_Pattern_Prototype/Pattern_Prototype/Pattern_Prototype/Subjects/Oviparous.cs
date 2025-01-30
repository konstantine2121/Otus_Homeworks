namespace Pattern_Prototype.Subjects
{

    /// <summary>
    /// Яйцекладущие <br/>
    /// Является наследником <see cref="Animal">животного</see><br/>
    /// Добавляется свойство <see cref="AmountOfEggs">количество откладываемых яиц</see>
    /// </summary>
    public class Oviparous : Animal, IMyCloneable<Oviparous>
    {
        public Oviparous(bool alive, int age, Gender gender, int amountOfEggs) : base(alive, age, gender)
        {
            AmountOfEggs = amountOfEggs;
        }

        protected Oviparous(Oviparous creature) : base(creature)
        {
            AmountOfEggs = creature.AmountOfEggs;
        }

        /// <summary>
        /// Количество откладываемых яиц
        /// </summary>
        public int AmountOfEggs { get; }

        Oviparous IMyCloneable<Oviparous>.Clone()
        {
            return new Oviparous(this);
        }

        public override object Clone()
        {
            return new Oviparous(this);
        }
    }
}