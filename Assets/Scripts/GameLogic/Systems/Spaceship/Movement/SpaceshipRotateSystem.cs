using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View.Components;

namespace GameLogic.Systems.Spaceship.Movement
{
    public class SpaceshipRotateSystem : IEcsRunSystem
    {
        private Group<Component<ITransform>, PlayerComponent> _filter;
        private IInput _input;
        private IDeltaTime _deltaTime;
        [IgnoreInject] private const int RotateSpeed = -250;

        public void Run()
        {
            if (_filter.IsEmpty == false && _input.Rotation != 0)
            {
                ref var transform = ref _filter.Get1(0).Value;
                transform.Rotate(RotateSpeed * _input.Rotation * _deltaTime.Value);
            }
        }
    }
}