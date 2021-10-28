using CustomEcs.EcsWorldHandlers;

namespace CustomEcs
{
    public class EcsWorld
    {
        private EcsWordData _ecsWordData;
        internal ComponentsPoolRequestHandler ComponentsPoolRequestHandler { get; }
        internal DeletedComponentsHandler DeletedComponentsHandler { get; }

        public EcsWorld()
        {
            _ecsWordData = new EcsWordData();
            ComponentsPoolRequestHandler = new ComponentsPoolRequestHandler(_ecsWordData);
            DeletedComponentsHandler = new DeletedComponentsHandler(_ecsWordData);
        }

        public EcsEntity NewEntity() => new EcsEntity(this, _ecsWordData.EntityIdGenerator.GetId());
    }
}