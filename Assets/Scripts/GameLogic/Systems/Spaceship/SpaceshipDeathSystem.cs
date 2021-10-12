using GameLogic.Components;
using GameLogic.Events;
using Leopotam.Ecs;

namespace GameLogic.Systems.Spaceship
{
    public class SpaceshipDeathSystem : IEcsRunSystem
    {
        private EcsFilter<CollisionEvent, PlayerComponent> _filter;

        public void Run()
        {
            if (_filter.IsEmpty() == false)
            {
                _filter.GetEntity(0).Replace(new DeathComponent());
            }
        }
    }
}