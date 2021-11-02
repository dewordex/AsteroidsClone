using System.Numerics;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;

namespace GameLogic.Systems.Asteroid
{
    public class AsteroidsDirectionSystem : IEcsRunSystem
    {
        Group<MotionDirectionComponent, PositionComponent, SetupDirectionComponent, AsteroidComponent> _filter;
        private IRandom _random;
        private ICamera _camera;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var motionDirectionComponent = ref _filter.Get1(i);
                ref var positionComponent = ref _filter.Get2(i);
                var randomPositionInsideCamera = _random.GetRandomPositionInsideCamera(_camera.OrthographicSize, _camera.Aspect);
                motionDirectionComponent.Direction = Vector2.Normalize(randomPositionInsideCamera - positionComponent.Position);
                _filter.GetEntity(i).Delete<SetupDirectionComponent>();
            }
        }
    }
}