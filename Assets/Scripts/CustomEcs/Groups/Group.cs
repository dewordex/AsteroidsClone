using System.Collections.Generic;

namespace CustomEcs.Groups
{
    public class Group<TComponent> : IGroup where TComponent : struct
    {
        private readonly Dictionary<uint, uint> _verifiableEntities = new Dictionary<uint, uint>();
        private readonly Dictionary<uint, int> _links = new Dictionary<uint, int>();
        protected readonly List<uint> Entities = new List<uint>();
        protected EcsWorld World { get; }
        protected uint RequiredNumberComponents = 1;

        public Group(EcsWorld world)
        {
            World = world;
            Subscribe<TComponent>();
        }

        public bool IsEmpty => Entities.Count == 0;
        public EcsEntity GetEntity(int index) => new EcsEntity(World, Entities[index]);
        public ref TComponent Get1(int index) => ref World.ComponentsPoolRequestHandler.Get<TComponent>(Entities[index]);

        protected void Subscribe<T>() where T : struct
        {
            var componentsPool = World.ComponentsPoolRequestHandler.GetBasePool<T>();
            componentsPool.ComponentAdded += OnComponentAdded;
            componentsPool.ComponentRemoved += OnComponentRemoved;
        }

        private void OnComponentAdded(uint entityId)
        {
            if (_verifiableEntities.ContainsKey(entityId))
            {
                _verifiableEntities[entityId] += 1;
            }
            else
            {
                _verifiableEntities.Add(entityId, 1);
            }

            if (_verifiableEntities[entityId] == RequiredNumberComponents)
            {
                Entities.Add(entityId);
                _links.Add(entityId, Entities.Count - 1);
            }
        }

        private void OnComponentRemoved(uint entityId)
        {
            if (_verifiableEntities.ContainsKey(entityId))
            {
                _verifiableEntities[entityId] -= 1;
                if (_verifiableEntities[entityId] == 0) _verifiableEntities.Remove(entityId);

                if (_links.ContainsKey(entityId))
                {
                    var lastEntityId = Entities[Entities.Count - 1];
                    Entities.RemoveAt(Entities.Count - 1);

                    if (_links[entityId] != _links[lastEntityId])
                    {
                        var deletedEntityIndex = _links[entityId];
                        Entities[deletedEntityIndex] = lastEntityId;
                        _links.Remove(lastEntityId);
                        _links.Add(lastEntityId, deletedEntityIndex);
                    }

                    _links.Remove(entityId);
                }
            }
        }

        public Enumerator GetEnumerator() => new Enumerator(this);
        public int GetEntitiesCount() => Entities.Count;
    }

    public class Group<TComponent1, TComponent2> : Group<TComponent1> where TComponent1 : struct where TComponent2 : struct
    {
        public ref TComponent2 Get2(int index) => ref World.ComponentsPoolRequestHandler.Get<TComponent2>(Entities[index]);

        public Group(EcsWorld world) : base(world)
        {
            RequiredNumberComponents = 2;
            Subscribe<TComponent2>();
        }
    }

    public class Group<TComponent1, TComponent2, TComponent3> : Group<TComponent1, TComponent2> where TComponent1 : struct where TComponent2 : struct where TComponent3 : struct
    {
        public ref TComponent3 Get3(int index) => ref World.ComponentsPoolRequestHandler.Get<TComponent3>(Entities[index]);

        public Group(EcsWorld world) : base(world)
        {
            RequiredNumberComponents = 3;
            Subscribe<TComponent3>();
        }
    }

    public class Group<TComponent1, TComponent2, TComponent3, TComponent4> : Group<TComponent1, TComponent2, TComponent3>
        where TComponent1 : struct where TComponent2 : struct where TComponent3 : struct where TComponent4 : struct
    {
        public ref TComponent4 Get4(int index) => ref World.ComponentsPoolRequestHandler.Get<TComponent4>(Entities[index]);

        public Group(EcsWorld world) : base(world)
        {
            RequiredNumberComponents = 4;
            Subscribe<TComponent4>();
        }
    }

    public class Group<TComponent1, TComponent2, TComponent3, TComponent4, TComponent5> : Group<TComponent1, TComponent2, TComponent3, TComponent4>
        where TComponent1 : struct where TComponent2 : struct where TComponent3 : struct where TComponent4 : struct where TComponent5 : struct
    {
        public ref TComponent5 Get5(int index) => ref World.ComponentsPoolRequestHandler.Get<TComponent5>(Entities[index]);

        public Group(EcsWorld world) : base(world)
        {
            RequiredNumberComponents = 5;
            Subscribe<TComponent5>();
        }
    }
}