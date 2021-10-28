namespace CustomEcs
{
    public struct EcsEntity
    {
        private readonly EcsWorld _world;
        private readonly uint _id;
        public bool IsAlive { get; private set; }

        public EcsEntity(EcsWorld world, uint id)
        {
            _world = world;
            _id = id;
            IsAlive = true;
        }

        public readonly EcsEntity Replace<T>(T component) where T : struct
        {
            _world.ComponentsPoolRequestHandler.Replace(component, _id);
            return this;
        }

        public void Delete<T>() where T : struct => _world.ComponentsPoolRequestHandler.Delete<T>(_id);

        public void Destroy()
        {
            IsAlive = false;
            _world.ComponentsPoolRequestHandler.Destroy(_id);
        }

        public bool Has<T>() where T : struct => _world.ComponentsPoolRequestHandler.Has<T>(_id);
        public ref T Get<T>() where T : struct => ref _world.ComponentsPoolRequestHandler.Get<T>(_id);
    }
}