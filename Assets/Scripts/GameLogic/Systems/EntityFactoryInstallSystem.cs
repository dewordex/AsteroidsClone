using CustomEcs;
using CustomEcs.Systems;
using GameLogic.Dependencies.View;
using GameLogic.Descriptions;

namespace GameLogic.Systems
{
    public class EntityFactoryInstallSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private IViewLoader _viewLoader;
        private EntitiesDescriptionsGenerator _entitiesDescriptionsGenerator;
        private IEntityFactorySettings _entityFactory;

        public void Init() => _entityFactory.Init(_world, _viewLoader, _entitiesDescriptionsGenerator);
    }
}