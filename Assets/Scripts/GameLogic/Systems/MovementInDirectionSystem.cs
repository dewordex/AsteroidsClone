using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;

namespace GameLogic.Systems
{
    public class MovementInDirectionSystem : IEcsRunSystem
    {
        private Group<MotionDirectionComponent, PositionComponent, VelocityComponent> _filter;
        private IDeltaTime _deltaTime;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var motionDirectionComponent = ref _filter.Get1(i);
                ref var positionComponent = ref _filter.Get2(i);
                ref var velocityComponent = ref _filter.Get3(i);
                positionComponent.Position += velocityComponent.InstantVelocity.Length() * motionDirectionComponent.Direction * _deltaTime.Value;
            }
        }
    }
}