namespace Pattern_Prototype.Subjects
{
    /// <summary>
    /// Живородящие <br/>
    /// Является наследником <see cref="Animal">животного</see><br/>
    /// Добавляется свойство <see cref="GrowthPeriod">время созревания плода</see>
    /// </summary>
    public class Theria : Animal, IMyCloneable<Theria>
    {
        public Theria(bool alive, int age, Gender gender, TimeSpan growthPeriod) : base(alive, age, gender)
        {
            GrowthPeriod = growthPeriod;
        }

        protected Theria(Theria creature) : base(creature)
        {
            GrowthPeriod = creature.GrowthPeriod;
        }

        /// <summary>
        /// Время созревания плода
        /// </summary>
        public TimeSpan GrowthPeriod { get; }

        Theria IMyCloneable<Theria>.Clone()
        {
            return new Theria(this);
        }

        public override object Clone()
        {
            return new Theria(this);
        }
    }
}