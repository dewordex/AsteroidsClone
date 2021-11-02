using CustomEcs;


namespace GameLogic.Factories
{
    public class BaseFactory
    {
        private EcsWorld _world;
        private EcsEntity _entity;
        private bool _isEntityCreated;

        public BaseFactory(EcsWorld world) => _world = world;

        protected EcsEntity Entity
        {
            get
            {
                if (_isEntityCreated == false)
                {
                    _entity = _world.NewEntity();
                    _isEntityCreated = true;
                }

                return _entity;
            }
        }
        

        protected void Add<T>(T component) where T : struct => Entity.Replace(component);
    }
}