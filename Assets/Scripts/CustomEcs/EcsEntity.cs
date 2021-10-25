namespace CustomEcs
{
    public readonly struct EcsEntity
    {
        private readonly EcsWorld _world;
        private readonly uint _id;

        public EcsEntity(EcsWorld world, uint id)
        {
            _world = world;
            _id = id;
        }

        public EcsEntity Replace<T>(T component) where T : struct
        {
            var componentsPool = _world.GetPool<T>();
            componentsPool.Replace(_id, component);
            _world.AddIdentifierForEntityComponent<T>(_id);
            return this;
        }

        public void Delete<T>() where T : struct
        {
            var componentsPool = _world.GetPool<T>();
            componentsPool.Delete(_id);
            _world.RemoveIdentifierForEntityComponent<T>(_id);
        }
        
        public void Destroy()
        {
            var identifiersForEntityComponents = _world.GetIdentifiersForEntityComponents(_id);
            foreach (var identifiersForEntityComponent in identifiersForEntityComponents)
            {
                _world.GetPoolByIndex(identifiersForEntityComponent).Delete(_id);
            }
        }

        public bool Has<T>() where T : struct
        {
            var componentsPool = _world.GetPool<T>();
            return componentsPool.HasEntity(_id);
        }

        public ref T Get<T>() where T : struct
        {
            var componentsPool = _world.GetPool<T>();
            _world.AddIdentifierForEntityComponent<T>(_id);
            return ref componentsPool.Get(_id);
        }
    }
}