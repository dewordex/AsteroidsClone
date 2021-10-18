using GameLogic.Components;
using Leopotam.Ecs;

namespace GameLogic.Systems.Asteroid
{
    public class AsteroidDeathSystem : IEcsRunSystem
    {
        private EcsFilter<DeathComponent, AsteroidComponent> _filter;
        private EcsFilter<AsteroidsSessionComponent> _asteroidSessionFilter;

        public void Run()
        {
            if (_asteroidSessionFilter.IsEmpty() == false)
            {
                ref var asteroidsSessionComponent = ref _asteroidSessionFilter.Get1(0);;
                foreach (var unused in _filter)
                {
                    asteroidsSessionComponent.AsteroidsCount--;
                }
            }
        }
    }
}