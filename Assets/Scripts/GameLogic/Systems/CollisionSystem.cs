using System.Linq;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Events;

namespace GameLogic.Systems
{
    public class CollisionSystem : IEcsRunSystem
    {
        private Group<CollisionEvent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var collisionEvent = _filter.Get1(i);
                foreach (var valueTuple in collisionEvent.CollisionList.Where(valueTuple => valueTuple.target.IsAlive))
                {
                    valueTuple.target.Replace(new DeathComponent());
                    valueTuple.sender.Replace(new DeathComponent());
                }
            }
        }
    }
}