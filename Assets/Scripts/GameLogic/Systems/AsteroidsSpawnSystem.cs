using System;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Components;
using GameLogic.Descriptions.Ids;
using GameLogic.Descriptions.Settings;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class AsteroidsSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private AsteroidsSpawnSetting _spawnSetting;
        private IEntityFactory _entityFactory;
        private IRandom _random;
        private ICamera _camera;

        private EcsFilter<AsteroidsSessionComponent> _asteroidSessionFilter;
        private EcsFilter<TimeSessionComponent> _timeSessionFilter;

        [EcsIgnoreInject] private Random _intRandom = new Random();
        public void Init() => _world.NewEntity().Replace(new AsteroidsSessionComponent());

        public void Run()
        {
            if (_asteroidSessionFilter.IsEmpty() == false && _timeSessionFilter.IsEmpty() == false)
            {
                ref var asteroidsSessionComponent = ref _asteroidSessionFilter.Get1(0);
                var maxAsteroids = _spawnSetting.GetMaxAsteroids(_timeSessionFilter.Get1(0).Time);
                var asteroidsCount = maxAsteroids - asteroidsSessionComponent.AsteroidsCount;

                for (int i = 0; i < asteroidsCount; i++)
                {
                    var asteroidComponentsContainer = new AsteroidComponentsContainer();
                    var descriptionId = _intRandom.Next(0, 2) == 1 ? DescriptionIds.AsteroidDefault : DescriptionIds.AsteroidFast;
                    _entityFactory.StartCreate(asteroidComponentsContainer, descriptionId).Completed += handle =>
                    {
                        asteroidComponentsContainer.View.Transform.Position =
                            _random.GetRandomPositionOutsideCamera(asteroidComponentsContainer.View.Transform.Scale.Length(), _camera.OrthographicSize, _camera.Aspect);
                    };
                    asteroidsSessionComponent.AsteroidsCount++;
                }
            }
        }
    }
}