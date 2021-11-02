using System;
using System.Numerics;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;

namespace GameLogic.Systems.Teleportation
{
    public class TeleportationSystem : IEcsRunSystem
    {
        private Group<PositionComponent, VelocityComponent> _filter;
        private ICamera _camera;
        private const float Offset = 0.1f;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var positionComponent = ref _filter.Get1(i);
                var isInSectorX = -_camera.OrthographicSize * _camera.Aspect - 1 < positionComponent.Position.X && positionComponent.Position.X < _camera.OrthographicSize * _camera.Aspect + 1;
                var isInSectorY = -_camera.OrthographicSize - 1 < positionComponent.Position.Y && positionComponent.Position.Y < _camera.OrthographicSize + 1;

                if (isInSectorX == false)
                {
                    positionComponent.Position = new Vector2(-positionComponent.Position.X + Math.Sign(positionComponent.Position.X) * Offset, positionComponent.Position.Y);
                }

                if (isInSectorY == false)
                {
                    positionComponent.Position = new Vector2(positionComponent.Position.X, -positionComponent.Position.Y + Math.Sign(positionComponent.Position.Y) * Offset);
                }
            }
        }
    }
}