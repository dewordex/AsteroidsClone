using System.Numerics;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;

namespace GameLogic.Systems.Spaceship.Movement
{
    public class SpaceshipVelocitySystem : IEcsRunSystem
    {
        private Group<VelocityComponent, RigidbodyComponent, RotationComponent , PlayerComponent> _filter;
        private IInput _input;
        private IDeltaTime _deltaTime;

        public void Run()
        {
            if (_filter.IsEmpty == false)
            {
                ref var velocityComponent = ref _filter.Get1(0);
                ref var rigidbodyComponent = ref _filter.Get2(0);
                ref var rotationComponent = ref _filter.Get3(0);
                velocityComponent.InstantVelocity = _input.Forward * (rigidbodyComponent.Acceleration * rotationComponent.RotationDirection);
                velocityComponent.ActualVelocity = Vector2.Lerp(velocityComponent.ActualVelocity, velocityComponent.InstantVelocity, _deltaTime.Value / rigidbodyComponent.Mass);
            }
        }
    }
}