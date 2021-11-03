using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;

namespace GameLogic.Systems.Asteroid
{
    public class AsteroidDeathSystem : IEcsRunSystem
    {
        private Group<DeathComponent, AsteroidComponent> _filter;
        private Group<AsteroidsSessionComponent> _asteroidSessionFilter;

        public void Run()
        {
            if (_asteroidSessionFilter.IsEmpty == false)
            {
                ref var asteroidsSessionComponent = ref _asteroidSessionFilter.Get1(0);
                foreach (var unused in _filter)
                {
                    asteroidsSessionComponent.AsteroidsCount--;
                }
            }
        }
    }
}