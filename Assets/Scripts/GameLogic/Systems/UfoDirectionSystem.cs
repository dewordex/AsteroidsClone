using System.Numerics;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;

namespace GameLogic.Systems
{
    public class UfoDirectionSystem : IEcsRunSystem
    {
        private Group<MotionDirectionComponent, PositionComponent, UfoComponent> _ufoFilter;
        private Group<PositionComponent, PlayerComponent> _spaceshipFilter;

        public void Run()
        {
            if (_spaceshipFilter.IsEmpty == false)
            {
                foreach (var i in _ufoFilter)
                {
                    ref var motionDirectionComponent = ref _ufoFilter.Get1(i);
                    ref var ufoPosition = ref _ufoFilter.Get2(i);
                    var spaceshipPosition = _spaceshipFilter.Get1(0);
                    motionDirectionComponent.Direction =  Vector2.Normalize(spaceshipPosition.Position - ufoPosition.Position);
                }
            }
        }
    }
}