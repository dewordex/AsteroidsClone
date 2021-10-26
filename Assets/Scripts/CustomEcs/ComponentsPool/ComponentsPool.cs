using System;
using System.Collections.Generic;

namespace CustomEcs.ComponentsPool
{
    internal class ComponentsPool<T> : IComponentsPool<T> where T : struct
    {
        private T[] _items = new T[128];
        private HashSet<uint> _entities = new HashSet<uint>();
        public bool HasEntity(uint entityId) => _entities.Contains(entityId);

        public ref T Get(uint entityId)
        {
            if (HasEntity(entityId) == false)
            {
                AddEntity(entityId);
            }

            return ref _items[entityId];
        }

        public void Replace(uint entityId, T component)
        {
            if (HasEntity(entityId) == false)
            {
                AddEntity(entityId);
            }

            _items[entityId] = component;
        }

        public void Delete(uint entityId)
        {
            _entities.Remove(entityId);
            _items[entityId] = default;
            ComponentRemoved(entityId);
        }

        private void AddEntity(uint entityId)
        {
            if (_items.Length - 1 <= entityId) Array.Resize(ref _items, (int)(entityId << 1));
            _entities.Add(entityId);
            ComponentAdded(entityId);
        }

        public event Action<uint> ComponentAdded = delegate { };
        public event Action<uint> ComponentRemoved = delegate { };
    }
}