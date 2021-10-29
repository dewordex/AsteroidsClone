using System;
using System.Collections.Generic;
using CustomEcs.ComponentsPool;

namespace CustomEcs.EcsWorldHandlers
{
    internal class ComponentsPoolRequestHandler
    {
        private EcsWordData _ecsWordData;
        public ComponentsPoolRequestHandler(EcsWordData ecsWordData) => _ecsWordData = ecsWordData;

        public void Replace<T>(T component, uint entityID) where T : struct
        {
            var componentsPool = GetPool<T>();
            if (componentsPool.HasEntity(entityID) == false)
            {
                AddIdentifierForEntityComponent(entityID, EcsComponentType<T>.TypeIndex);
            }

            componentsPool.Replace(entityID, component);
        }

        public void Delete<T>(uint entityID) where T : struct => MarkForDelete(entityID, EcsComponentType<T>.TypeIndex);

        public void Destroy(uint entityID)
        {
            foreach (var componentTypeIndex in _ecsWordData.GetEntitiesComponents()[entityID])
            {
                MarkForDelete(entityID, componentTypeIndex);
            }
        }

        public bool Has<T>(uint entityID) where T : struct => GetPool<T>().HasEntity(entityID);
        public ref T Get<T>(uint entityID) where T : struct => ref GetPool<T>().Get(entityID);

        public IBaseComponentsPool GetBasePool<T>() where T : struct => GetPool<T>();

        private IComponentsPool<T> GetPool<T>() where T : struct
        {
            ref var componentsPools = ref _ecsWordData.GetComponentsPools();
            var typeIndex = EcsComponentType<T>.TypeIndex;
            var pool = componentsPools[typeIndex];
            if (pool == null)
            {
                pool = new ComponentsPool<T>();
                componentsPools[typeIndex] = pool;
            }

            return (IComponentsPool<T>)pool;
        }

        private void AddIdentifierForEntityComponent(uint id, int componentTypeIndex)
        {
            ref var entitiesComponents = ref _ecsWordData.GetEntitiesComponents();
            if (_ecsWordData.GetEntitiesComponents().Length == id) Array.Resize(ref entitiesComponents, (int)(id << 1));
            if (entitiesComponents[id] == null) entitiesComponents[id] = new HashSet<int>();
            entitiesComponents[id].Add(componentTypeIndex);
        }

        private void MarkForDelete(uint entityId, int componentTypeIndex) =>
            _ecsWordData.ComponentsMarkedForDeletion.Add(new DeletedComponentData() { EntityId = entityId, ComponentTypeIndex = componentTypeIndex });
    }
}