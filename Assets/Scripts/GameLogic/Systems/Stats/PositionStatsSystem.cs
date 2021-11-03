using System;
using System.Numerics;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Systems.Stats
{
    public class PositionStatsSystem : IEcsRunSystem
    {
        private Group<PositionComponent, PlayerComponent> _group;
        private IStatsView _statsView;
        [IgnoreInject] private Vector2 _lastPosition = new Vector2(-1, -1);

        public void Run()
        {
            if (_group.IsEmpty == false)
            {
                var positionComponent = _group.Get1(0);
                var delta = positionComponent.Position - _lastPosition;
                if (Math.Abs(delta.X) >= 1 || Math.Abs(delta.Y) >= 1)
                {
                    _lastPosition = positionComponent.Position;
                    _statsView.UpdatePosition(positionComponent.Position.X.ToString("F0"), positionComponent.Position.Y.ToString("F0"));
                }
            }
        }
    }
}