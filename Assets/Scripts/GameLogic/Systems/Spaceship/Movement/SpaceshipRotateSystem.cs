using System;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Utility;

namespace GameLogic.Systems.Spaceship.Movement
{
    public class SpaceshipRotateSystem : IEcsRunSystem
    {
        private Group<RotationComponent, PlayerComponent> _filter;
        private IInput _input;
        private IDeltaTime _deltaTime;
        [IgnoreInject] private const int RotateSpeed = -250;

        public void Run()
        {
            if (_filter.IsEmpty == false && _input.Rotation != 0)
            {
                ref var rotationComponent = ref _filter.Get1(0);
                var rotationAngle = RotateSpeed * _input.Rotation * _deltaTime.Value;
                rotationComponent.RotationAngle -= rotationAngle;
                if (Math.Abs(rotationComponent.RotationAngle) - 180 > 0)
                    rotationComponent.RotationAngle = -rotationComponent.RotationAngle;
                rotationComponent.RotationDirection = rotationComponent.RotationDirection.Rotate(rotationAngle);
            }
        }
    }
}