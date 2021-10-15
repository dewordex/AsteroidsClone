using GameLogic.Components;
using GameLogic.Dependencies;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class ShootDelaySystem : IEcsRunSystem
    {
        private IDeltaTime _deltaTime;
        private EcsFilter<ShotDelayComponent> _shootDelayFilter;

        public void Run()
        {
            foreach (var i in _shootDelayFilter)
            {
                _shootDelayFilter.Get1(i).Delay -= _deltaTime.Value;
            }
        }
    }
}