using System;
using System.Numerics;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View.Components;

namespace GameLogic.Systems.Teleportation
{
    public class TeleportationSystem : IEcsRunSystem
    {
        private Group<Component<ITransform>, VelocityComponent> _filter;
        private ICamera _camera;
        private const float Offset = 0.1f;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transform = ref _filter.Get1(i).Value;
                var isInSectorX = -_camera.OrthographicSize * _camera.Aspect - transform.Scale.X < transform.Position.X && transform.Position.X < _camera.OrthographicSize * _camera.Aspect + transform.Scale.X;
                var isInSectorY = -_camera.OrthographicSize - transform.Scale.Y < transform.Position.Y && transform.Position.Y < _camera.OrthographicSize + transform.Scale.Y;

                if (isInSectorX == false)
                {
                    transform.Position = new Vector2(-transform.Position.X + Math.Sign(transform.Position.X) * Offset, transform.Position.Y);
                }

                if (isInSectorY == false)
                {
                    transform.Position = new Vector2(transform.Position.X, -transform.Position.Y + Math.Sign(transform.Position.Y) * Offset);
                }
            }
        }
    }
}