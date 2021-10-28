using System.Collections.Generic;
using CustomEcs.ComponentsPool;

namespace CustomEcs
{
    internal class EcsWordData
    {
        private HashSet<int>[] _entitiesComponents = new HashSet<int>[128];
        private IComponentsPool[] _componentsPools = new IComponentsPool[512];
        public IdGenerator EntityIdGenerator { get; } = new IdGenerator();
        public HashSet<DeletedComponentData> ComponentsMarkedForDeletion { get; } = new HashSet<DeletedComponentData>();

        public ref HashSet<int>[] GetEntitiesComponents() => ref _entitiesComponents;
        public ref IComponentsPool[] GetComponentsPools() => ref _componentsPools;
    }
}