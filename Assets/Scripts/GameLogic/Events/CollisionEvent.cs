using System.Collections.Generic;
using Leopotam.Ecs;

namespace GameLogic.Events
{
    public struct CollisionEvent
    {
        public List<(EcsEntity sender, EcsEntity target)> CollisionList;
    }
}