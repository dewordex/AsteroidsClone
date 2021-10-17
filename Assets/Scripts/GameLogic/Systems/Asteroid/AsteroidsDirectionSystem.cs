using System.Numerics;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View.Components;
using Leopotam.Ecs;

namespace GameLogic.Systems.Asteroid
{
    public class AsteroidsDirectionSystem : IEcsRunSystem
    {
        EcsFilter<MotionDirectionComponent, Component<ITransform>, AsteroidComponent>.Exclude<LockDirectionComponent> _filter;
        private IRandom _random;
        private ICamera _camera;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var motionDirectionComponent = ref _filter.Get1(i);
                ref var transform = ref _filter.Get2(i).Value;
                var randomPositionInsideCamera = _random.GetRandomPositionInsideCamera(_camera.OrthographicSize, _camera.Aspect);
                motionDirectionComponent.Direction = Vector2.Normalize(randomPositionInsideCamera - transform.Position);
                _filter.GetEntity(i).Replace(new LockDirectionComponent());
            }
        }
    }
}