using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View.Components;

namespace GameLogic.Systems.Spaceship.Movement
{
    public class SpaceshipMovementSystem : IEcsRunSystem
    {
        private Group<VelocityComponent, Component<ITransform>, PlayerComponent> _filter;
        private IDeltaTime _deltaTime;

        public void Run()
        {
            if (_filter.IsEmpty == false)
            {
                ref var velocityComponent = ref _filter.Get1(0);
                ref var transform = ref _filter.Get2(0).Value;
                transform.Position += velocityComponent.ActualVelocity * _deltaTime.Value;
            }
        }
    }
}