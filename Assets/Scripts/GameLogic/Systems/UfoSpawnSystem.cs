using GameLogic.Dependencies;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Components;
using GameLogic.Descriptions.Ids;
using GameLogic.Descriptions.Settings;
using GameLogic.Utility;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class UfoSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private IRandom _random;
        private ICamera _camera;
        private IEntityFactory _factory;
        private IDeltaTime _deltaTime;
        private EcsWorld _world;
        private UfoSpawnSetting _spawnSetting;

        [EcsIgnoreInject] private Timer _timer;

        public void Init() => StartTimer();

        public void Run() => _timer.Update(_deltaTime.Value);

        private void SpawnUfo()
        {
            var ufoComponentsContainer = new UfoComponentsContainer();
            _factory.StartCreate(ufoComponentsContainer, DescriptionIds.UfoDefault).Completed += handle =>
            {
                var movableView = ufoComponentsContainer.View;
                movableView.Transform.Position = _random.GetRandomPositionOutsideCamera(movableView.Transform.Scale.Length(), _camera.OrthographicSize, _camera.Aspect);
            };

            StartTimer();
        }

        private void StartTimer()
        {
            _timer = new Timer(_random.Range(_spawnSetting.SpawnTimeRange.Min, _spawnSetting.SpawnTimeRange.Max), autoReset: false);
            _timer.Elapsed += SpawnUfo;
        }
    }
}