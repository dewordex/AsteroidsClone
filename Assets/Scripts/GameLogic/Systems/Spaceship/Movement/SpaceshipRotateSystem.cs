using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View.Components;
using Leopotam.Ecs;

namespace GameLogic.Systems.Spaceship.Movement
{
    public class SpaceshipRotateSystem : IEcsRunSystem
    {
        private EcsFilter<Component<ITransform>, PlayerComponent> _filter;
        private IInput _input;
        [EcsIgnoreInject] private const int RotateSpeed = -1;

        public void Run()
        {
            if (_filter.IsEmpty() == false)
            {
                ref var transform = ref _filter.Get1(0).Value;
                transform.Rotate(RotateSpeed * _input.Rotation);
            }
        }
    }
}