using System;
using System.Numerics;
using CustomEcs;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Ids;
using GameLogic.Factories;

namespace GameLogic.Systems.Asteroid
{
    public class AsteroidsSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private FactoriesContainer _factoriesContainer;
        private DescriptionsContainer _descriptionsContainer;
        private IRandom _random;
        private ICamera _camera;

        private Group<AsteroidsSessionComponent> _asteroidSessionFilter;
        private Group<TimeSessionComponent> _timeSessionFilter;

        [IgnoreInject] private Random _intRandom = new Random();
        public void Init() => _world.NewEntity().Replace(new AsteroidsSessionComponent());

        public void Run()
        {
            if (_asteroidSessionFilter.IsEmpty == false && _timeSessionFilter.IsEmpty == false)
            {
                var description = _descriptionsContainer.AsteroidSpawnDescriptionContainer.Get(DescriptionIds.AsteroidSpawnSettings);
                ref var asteroidsSessionComponent = ref _asteroidSessionFilter.Get1(0);
                var maxAsteroids = description.GetMaxAsteroids(_timeSessionFilter.Get1(0).Time);
                var asteroidsCount = maxAsteroids - asteroidsSessionComponent.AsteroidsCount;

                for (int i = 0; i < asteroidsCount; i++)
                {
                    var position = _random.GetRandomPositionOutsideCamera(3, _camera.OrthographicSize, _camera.Aspect);

                    SpawnAsync(position);
                    asteroidsSessionComponent.AsteroidsCount++;
                }
            }
        }

        private async void SpawnAsync(Vector2 position)
        {
            var descriptionId = _intRandom.Next(0, 2) == 1 ? DescriptionIds.AsteroidDefault : DescriptionIds.AsteroidFast;
            var movableDescription = _descriptionsContainer.MovableDescriptionsContainer.Get(descriptionId);
            var asteroidFactory = _factoriesContainer.GetAsteroidFactory();
            await asteroidFactory.CreateViewAsync<IMovableView>(movableDescription.ViewKey);
            asteroidFactory.CreateEntity(position, movableDescription.InstantVelocity, movableDescription.Score);
        }
    }
}