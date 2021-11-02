using CustomEcs;
using CustomEcs.Systems;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Ids;
using GameLogic.Factories;
using GameLogic.Utility;

namespace GameLogic.Systems
{
    public class UfoSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private IRandom _random;
        private ICamera _camera;
        private IDeltaTime _deltaTime;
        private EcsWorld _world;
        private FactoriesContainer _factoriesContainer;
        private DescriptionsContainer _descriptionsContainer;

        [IgnoreInject] private Timer _timer;

        public void Init() => StartTimer();

        public void Run() => _timer.Update(_deltaTime.Value);

        private async void SpawnUfo()
        {
            var movableDescription = _descriptionsContainer.MovableDescriptionsContainer.Get(DescriptionIds.UfoDefault);
            var ufoFactory = _factoriesContainer.GetUfoFactory();
            await ufoFactory.CreateViewAsync<IMovableView>(movableDescription.ViewKey);
            ufoFactory.CreateEntity(_random.GetRandomPositionOutsideCamera(movableDescription.Size.X, _camera.OrthographicSize, _camera.Aspect), movableDescription.InstantVelocity, movableDescription.Score, movableDescription.Size);
            StartTimer();
        }

        private void StartTimer()
        {
            var ufoSpawnDescription = _descriptionsContainer.UfoSpawnDescriptionContainer.Get(DescriptionIds.UfoSpawnSettings);
            _timer = new Timer(_random.Range(ufoSpawnDescription.SpawnTimeRange.Min, ufoSpawnDescription.SpawnTimeRange.Max), autoReset: false);
            _timer.Elapsed += SpawnUfo;
        }
    }
}