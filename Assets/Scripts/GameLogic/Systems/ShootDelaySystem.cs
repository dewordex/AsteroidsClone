using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;

namespace GameLogic.Systems
{
    public class ShootDelaySystem : IEcsRunSystem
    {
        private IDeltaTime _deltaTime;
        private Group<ShotDelayComponent> _shootDelayFilter;

        public void Run()
        {
            foreach (var i in _shootDelayFilter)
            {
                _shootDelayFilter.Get1(i).CurrentDelay -= _deltaTime.Value;
            }
        }
    }
}