using CustomEcs;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;

namespace GameLogic.Systems.Spaceship.Movement
{
    public class SpaceshipMovementSystem : IEcsRunSystem
    {
        private Group<VelocityComponent, PositionComponent, PlayerComponent> _filter;
        private IDeltaTime _deltaTime;
        private EcsWorld _world;
        public void Run()
        {
            if (_filter.IsEmpty == false)
            {
                ref var velocityComponent = ref _filter.Get1(0);
                ref var positionComponent = ref _filter.Get2(0);
                positionComponent.Position += velocityComponent.ActualVelocity * _deltaTime.Value;
            }
        }
    }
}