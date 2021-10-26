using System;
using System.Numerics;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;

namespace GameLogic.Systems.Stats
{
    public class PositionStatsSystem : IEcsRunSystem
    {
        private Group<Component<ITransform>, PlayerComponent> _group;
        private IStatsView _statsView;
        [IgnoreInject] private Vector2 _lastPosition = new Vector2(-1,-1);

        public void Run()
        {
            if (_group.IsEmpty == false)
            {
                var component = _group.Get1(0).Value;
                var delta = component.Position - _lastPosition;
                if (Math.Abs(delta.X) >= 1 || Math.Abs(delta.Y) >= 1)
                {
                    _lastPosition = component.Position;
                    _statsView.UpdatePosition(component.Position.X.ToString("F0"), component.Position.Y.ToString("F0"));
                }
            }
        }
    }
}