using System.Linq;
using GameLogic.Components;
using GameLogic.Events;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class CollisionSystem : IEcsRunSystem
    {
        private EcsFilter<CollisionEvent>.Exclude<ManualCollisionProcessingComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var collisionEvent = _filter.Get1(i);
                foreach (var valueTuple in collisionEvent.CollisionList.Where(valueTuple => valueTuple.target.IsAlive()))
                {
                    valueTuple.target.Replace(new DeathComponent());
                    valueTuple.sender.Replace(new DeathComponent());
                }
            }
        }
    }
}