using System.Numerics;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View.Components;

namespace GameLogic.Systems.Spaceship.Movement
{
    public class SpaceshipVelocitySystem : IEcsRunSystem
    {
        private Group<VelocityComponent, RigidbodyComponent, Component<ITransform>, PlayerComponent> _filter;
        private IInput _input;
        private IDeltaTime _deltaTime;

        public void Run()
        {
            if (_filter.IsEmpty == false)
            {
                ref var velocityComponent = ref _filter.Get1(0);
                ref var rigidbodyComponent = ref _filter.Get2(0);
                ref var transform = ref _filter.Get3(0).Value;
                velocityComponent.InstantVelocity = _input.Forward * (rigidbodyComponent.Acceleration * transform.Up);
                velocityComponent.ActualVelocity = Vector2.Lerp(velocityComponent.ActualVelocity, velocityComponent.InstantVelocity, _deltaTime.Value / rigidbodyComponent.Mass);
            }
        }
    }
}