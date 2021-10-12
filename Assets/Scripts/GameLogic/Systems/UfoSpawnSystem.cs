using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View;
using GameLogic.Descriptions.Entities;
using GameLogic.Descriptions.Settings;
using GameLogic.Utility;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class UfoSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private IRandom _random;
        private ICamera _camera;
        private IViewLoader _viewLoader;
        private IDeltaTime _deltaTime;
        private EcsWorld _world;
        private UfoSpawnSetting _spawnSetting;

        private EcsFilter<TimerComponent<UfoSpawnSystem>> _filter;
        [EcsIgnoreInject] private Timer<UfoSpawnSystem> _timer;

        public void Init()
        {
            _timer = new Timer<UfoSpawnSystem>(_world, _deltaTime);
            StartTimer();
        }

        public void Run() => _timer.Update();

        private void SpawnUfo()
        {
            var ufoDescription = new UfoDescription();
            _viewLoader.InstantiateAsync<IMovableView>(ufoDescription.Key).Completed += handle =>
            {
                var newEntity = _world.NewEntity();
                var view = handle.Result;
                ufoDescription.InstallComponents(newEntity, view);
                view.Transform.Position = _random.GetRandomPositionOutsideCamera(view.Transform.Scale.Length(), _camera.OrthographicSize, _camera.Aspect);
            };

            _timer.Stop();
            StartTimer();
        }

        private void StartTimer() => _timer.Start(_filter, SpawnUfo, _random.Range(_spawnSetting.SpawnTimeRange.Min, _spawnSetting.SpawnTimeRange.Max));
    }
}