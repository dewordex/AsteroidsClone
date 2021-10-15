using GameLogic.Dependencies.View;
using GameLogic.Descriptions;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class EntityFactoryInstallSystem : IEcsPreInitSystem
    {
        private EcsWorld _world;
        private IViewLoader _viewLoader;
        private EntitiesDescriptionsGenerator _entitiesDescriptionsGenerator;
        private IEntityFactorySettings _entityFactory;
        
        public void PreInit() => _entityFactory.Init(_world, _viewLoader, _entitiesDescriptionsGenerator);
    }
}