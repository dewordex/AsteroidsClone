using System.Collections;
using System.Collections.Generic;

namespace CustomEcs.Groups
{
    public class Group<TComponent> : IGroup where TComponent : struct
    {
        private HashSet<uint> _entities = new HashSet<uint>();
        private Dictionary<uint, uint> _verifiableEntities = new Dictionary<uint, uint>();
        protected EcsWorld World { get; }
        protected uint RequiredNumberComponents = 1;

        public bool IsEmpty => _entities.Count == 0;

        public Group(EcsWorld world)
        {
            World = world;
            Subscribe<TComponent>();
        }
        
        public EcsEntity GetEntity(uint index) => new EcsEntity(World, index);
        public ref TComponent Get1(uint index) => ref World.GetPool<TComponent>().Get(index);

        protected void Subscribe<T>() where T : struct
        {
            var componentsPool = World.GetPool<T>();
            componentsPool.ComponentAdded += OnComponentAdded;
            componentsPool.ComponentRemoved += OnComponentRemoved;
        }

        protected void OnComponentAdded(uint obj)
        {
            if (_verifiableEntities.ContainsKey(obj))
            {
                _verifiableEntities[obj] += 1;
            }
            else
            {
                _verifiableEntities.Add(obj, 1);
            }

            if (_verifiableEntities[obj] == RequiredNumberComponents)
            {
                _entities.Add(obj);
            }
        }

        protected void OnComponentRemoved(uint obj)
        {
            if (_verifiableEntities.ContainsKey(obj))
            {
                _verifiableEntities[obj] -= 1;
                _entities.Remove(obj);
            }
        }

        public IEnumerator<uint> GetEnumerator() => _entities.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class Group<TComponent1, TComponent2> : Group<TComponent1> where TComponent1 : struct where TComponent2 : struct
    {
        public ref TComponent2 Get2(uint index) => ref World.GetPool<TComponent2>().Get(index);

        public Group(EcsWorld world) : base(world)
        {
            RequiredNumberComponents = 2;
            Subscribe<TComponent2>();
        }
    }

    public class Group<TComponent1, TComponent2, TComponent3> : Group<TComponent1, TComponent2> where TComponent1 : struct where TComponent2 : struct where TComponent3 : struct
    {
        public ref TComponent3 Get3(uint index) => ref World.GetPool<TComponent3>().Get(index);

        public Group(EcsWorld world) : base(world)
        {
            RequiredNumberComponents = 3;
            Subscribe<TComponent3>();
        }
    }

    public class Group<TComponent1, TComponent2, TComponent3, TComponent4> : Group<TComponent1, TComponent2, TComponent3>
        where TComponent1 : struct where TComponent2 : struct where TComponent3 : struct where TComponent4 : struct
    {
        public ref TComponent4 Get4(uint index) => ref World.GetPool<TComponent4>().Get(index);

        public Group(EcsWorld world) : base(world)
        {
            RequiredNumberComponents = 4;
            Subscribe<TComponent4>();
        }
    }
}