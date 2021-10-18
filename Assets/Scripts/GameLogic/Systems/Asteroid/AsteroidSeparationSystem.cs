using GameLogic.Components;
using GameLogic.Events;
using Leopotam.Ecs;

namespace GameLogic.Systems.Asteroid
{
    public class AsteroidSeparationSystem : IEcsRunSystem
    {
        private EcsFilter<CollisionEvent, BulletComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                foreach (var (_, target) in _filter.Get1(i).CollisionList)
                {
                    if (target.Has<AsteroidComponent>())
                    {
                        target.Replace(new MeteorSpawnEvent());
                    }
                }
            }
        }
    }
}