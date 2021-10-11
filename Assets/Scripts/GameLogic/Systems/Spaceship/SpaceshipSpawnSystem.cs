using GameLogic.Dependencies.View;
using GameLogic.Descriptions.Entities;
using Leopotam.Ecs;

namespace GameLogic.Systems.Spaceship
{
    public class SpaceshipSpawnSystem : IEcsInitSystem
    {
        private IViewLoader _viewLoader;
        private EcsWorld _world;
        public void Init()
        {
            var spaceshipDescription = new SpaceshipDescription();
            _viewLoader.InstantiateAsync<IView>(spaceshipDescription.Key).Completed += handle =>
            {
                var newEntity = _world.NewEntity();
                spaceshipDescription.InstallComponents(newEntity, handle.Result);
            };
        }
    }
}