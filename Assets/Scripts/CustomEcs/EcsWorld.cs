using System.Collections.Generic;
using CustomEcs.ComponentsPool;

namespace CustomEcs
{
    public class EcsWorld
    {
        private uint _ecsEntityCount;
        private IComponentsPool[] _componentsPools = new IComponentsPool[512];
        private Dictionary<uint, List<int>> _identifiersForEntityComponents = new Dictionary<uint, List<int>>();
        public EcsEntity NewEntity() => new EcsEntity(this, _ecsEntityCount++);

        internal IComponentsPool GetPoolByIndex(int typeIndex) => _componentsPools[typeIndex];

        internal ComponentsPool<T> GetPool<T>() where T : struct
        {
            var typeIndex = EcsComponentType<T>.TypeIndex;
            var pool = (ComponentsPool<T>)_componentsPools[typeIndex];
            if (pool == null)
            {
                pool = new ComponentsPool<T>();
                _componentsPools[typeIndex] = pool;
            }

            return pool;
        }

        internal List<int> GetIdentifiersForEntityComponents(uint id) => _identifiersForEntityComponents[id];

        internal void RemoveIdentifierForEntityComponent<TComponent>(uint id) where TComponent : struct
        {
            var typeIndex = EcsComponentType<TComponent>.TypeIndex;
            _identifiersForEntityComponents[id].Remove(typeIndex);
        }

        internal void AddIdentifierForEntityComponent<TComponent>(uint id) where TComponent : struct
        {
            var typeIndex = EcsComponentType<TComponent>.TypeIndex;
            if (_identifiersForEntityComponents.TryGetValue(id, out var identifiers))
            {
                if (identifiers.Contains(typeIndex) == false)
                    identifiers.Add(typeIndex);
            }
            else
            {
                _identifiersForEntityComponents.Add(id, new List<int>() { typeIndex });
            }
        }
    }
}