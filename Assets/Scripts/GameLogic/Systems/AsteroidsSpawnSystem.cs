using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View;
using GameLogic.Descriptions.Entities;
using GameLogic.Descriptions.Settings;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class AsteroidsSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private AsteroidsSpawnSetting _spawnSetting;
        private IViewLoader _viewLoader;
        private IRandom _random;
        private ICamera _camera;

        private EcsFilter<AsteroidsSessionComponent> _asteroidSessionFilter;
        private EcsFilter<TimeSessionComponent> _timeSessionFilter;

        public void Init() => _world.NewEntity().Replace(new AsteroidsSessionComponent());

        public void Run()
        {
            if (_asteroidSessionFilter.IsEmpty() == false && _timeSessionFilter.IsEmpty() == false)
            {
                ref var asteroidsSessionComponent = ref _asteroidSessionFilter.Get1(0);
                var maxAsteroids = _spawnSetting.GetMaxAsteroids(_timeSessionFilter.Get1(0).Time);
                var asteroidsCount = maxAsteroids - asteroidsSessionComponent.AsteroidsCount;
                var asteroidDescription = new AsteroidDescription();

                for (int i = 0; i < asteroidsCount; i++)
                {
                    _viewLoader.InstantiateAsync<IMovableView>(asteroidDescription.Key).Completed += handle =>
                    {
                        var result = handle.Result;
                        var newEntity = _world.NewEntity();
                        asteroidDescription.InstallComponents(newEntity, result);

                        result.Transform.Position = _random.GetRandomPositionOutsideCamera(result.Transform.Scale.Length(), _camera.OrthographicSize, _camera.Aspect);
                    };
                    asteroidsSessionComponent.AsteroidsCount++;
                }
            }
        }
    }
}