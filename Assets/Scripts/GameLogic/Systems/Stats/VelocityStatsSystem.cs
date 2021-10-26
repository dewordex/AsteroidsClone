using System;
using System.Numerics;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Systems.Stats
{
    public class VelocityStatsSystem : IEcsRunSystem
    {
        private Group<VelocityComponent, PlayerComponent> _group;
        private IStatsView _statsView;

        [IgnoreInject] private Vector2 _lastVelocity = new Vector2(-1,-1);

        public void Run()
        {
            if (_group.IsEmpty == false)
            {
                ref var velocityComponent = ref _group.Get1(0);
                var delta = _lastVelocity - velocityComponent.InstantVelocity;
                if (Math.Abs(delta.X) >= 1 && Math.Abs(delta.Y) >= 1)
                {
                    _lastVelocity = velocityComponent.InstantVelocity;
                    _statsView.UpdateSpeed($"{velocityComponent.InstantVelocity.Length():F0}");
                }
            }
        }
    }
}