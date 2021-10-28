using System;

namespace CustomEcs.ComponentsPool
{
    internal interface IComponentsPool : IBaseComponentsPool
    {
        void Delete(uint entityId);
    }
    
    internal interface IBaseComponentsPool
    {
        event Action<uint> ComponentAdded;
        event Action<uint> ComponentRemoved;
    }

    internal interface IComponentsPool<T> : IComponentsPool
    {
        bool HasEntity(uint entityId);
        ref T Get(uint entityId);
        void Replace(uint entityId, T component);
    }
}