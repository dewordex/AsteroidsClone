using System.Collections.Generic;
using CustomEcs;

namespace GameLogic.Events
{
    public struct CollisionEvent
    {
        public List<(EcsEntity sender, EcsEntity target)> CollisionList;
    }
}