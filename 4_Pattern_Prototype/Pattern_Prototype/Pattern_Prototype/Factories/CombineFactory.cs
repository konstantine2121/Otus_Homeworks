﻿using Pattern_Prototype.Subjects;

namespace Pattern_Prototype.Factories
{
    internal class CombineCreatureFactory
    {
        private readonly CreatureFactory _creatureFactory = new CreatureFactory();
        private readonly AnimalFactory _animalFactory = new AnimalFactory();
        private readonly OviparousFactory _oviparousFactory = new OviparousFactory();
        private readonly TheriaFactory _theriaFactory = new TheriaFactory();

        private readonly Dictionary<Type, Func<Creature>> _factoriesMap;

        public CombineCreatureFactory()
        {
            _factoriesMap = new Dictionary<Type, Func<Creature>>()
            {
                [typeof(Creature)] = () => _creatureFactory.Create(),
                [typeof(Animal)] = () => _animalFactory.Create(),
                [typeof(Oviparous)] = () => _oviparousFactory.Create(),
                [typeof(Theria)] = () => _theriaFactory.Create()
            };
        }

        public IReadOnlyList<Type> SupportedTypes => _factoriesMap.Keys.ToArray();

        public T Create<T>() where T : Creature
        {
            var type = typeof(T);

            return Create(type) as T;
        }

        public Creature Create(Type type)
        {
            if (!_factoriesMap.ContainsKey(type))
            {
                throw new ArgumentException($"Can't create {type.FullName}");
            }

            return _factoriesMap[type].Invoke();
        }

        public Creature CreateRandomSupportedType()
        {
            var types = SupportedTypes;
            var type = types[Random.Shared.Next(types.Count)];

            return Create(type);
        }
    }

    internal static class CombineFactoryExtensions
    {
        public static List<Creature> CreateCreaturesList(this CombineCreatureFactory combineFactory, int amount = 10)
        {
            var subjects = new List<Creature>();

            for (int i = 0; i < amount; i++)
            {
                subjects.Add(combineFactory.Create<Creature>());
            }

            return subjects;
        }

        public static List<Animal> CreateAnimalsList(this CombineCreatureFactory combineFactory, int amount = 10)
        {
            var subjects = new List<Animal>();

            for (int i = 0; i < amount; i++)
            {
                subjects.Add(combineFactory.Create<Animal>());
            }

            return subjects;
        }

        public static List<Oviparous> CreateOviparousList(this CombineCreatureFactory combineFactory, int amount = 10)
        {
            var subjects = new List<Oviparous>();

            for (int i = 0; i < amount; i++)
            {
                subjects.Add(combineFactory.Create<Oviparous>());
            }

            return subjects;
        }

        public static List<Theria> CreateTheriaList(this CombineCreatureFactory combineFactory, int amount = 10)
        {
            var subjects = new List<Theria>();

            for (int i = 0; i < amount; i++)
            {
                subjects.Add(combineFactory.Create<Theria>());
            }

            return subjects;
        }
    }
}
