using System;
using System.Collections.Generic;

namespace CustomEcs.ComponentsPool
{
    internal class ComponentsPool<T> : IComponentsPool where T : struct
    {
        private T[] _items = new T[128];
        private HashSet<uint> _hasEntity = new HashSet<uint>();
        public bool HasEntity(uint entityId) => _hasEntity.Contains(entityId);

        public ref T Get(uint entityId)
        {
            if (HasEntity(entityId) == false)
            {
                AddEntity(entityId);
            }

            return ref _items[entityId];
        }

        public void Replace(uint entityId, object component)
        {
            _items[entityId] = (T)component;
            if (HasEntity(entityId) == false)
            {
                AddEntity(entityId);
            }
        }

        public void Delete(uint entityId)
        {
            _hasEntity.Remove(entityId);
            _items[entityId] = default;
            ComponentRemoved(entityId);
        }

        private void AddEntity(uint entityId)
        {
            _hasEntity.Add(entityId);
            ComponentAdded(entityId);
        }

        public event Action<uint> ComponentAdded = delegate { };
        public event Action<uint> ComponentRemoved = delegate { };
    }
}