using System;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;

namespace GameLogic.Systems.Stats
{
    public class AngleStatsSystem : IEcsRunSystem
    {
        private Group<Component<ITransform>, PlayerComponent> _group;
        private IStatsView _statsView;
        [IgnoreInject] private float _lastAngle = -1;

        public void Run()
        {
            if (_group.IsEmpty == false)
            {
                var component = _group.Get1(0).Value;
                if (Math.Abs(_lastAngle - component.Angle) >= 1)
                {
                    _lastAngle = component.Angle;
                    _statsView.UpdateAngle(_lastAngle.ToString("F0"));
                }
            }
        }

    }
}