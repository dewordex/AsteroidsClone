using System;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Systems.Stats
{
    public class AngleStatsSystem : IEcsRunSystem
    {
        private Group<RotationComponent, PlayerComponent> _group;
        private IStatsView _statsView;
        [IgnoreInject] private float _lastAngle = -1;

        public void Run()
        {
            if (_group.IsEmpty == false)
            {
                var rotationComponent = _group.Get1(0);
                if (Math.Abs(_lastAngle - rotationComponent.RotationAngle) >= 1)
                {
                    _lastAngle = rotationComponent.RotationAngle;
                    _statsView.UpdateAngle(_lastAngle.ToString("F0"));
                }
            }
        }

    }
}