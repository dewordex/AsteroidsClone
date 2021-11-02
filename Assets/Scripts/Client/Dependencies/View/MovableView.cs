using Client.Dependencies.Addressable;
using GameLogic.Dependencies.View;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Client.Dependencies.View
{
    public class MovableView : BaseView, IMovableView
    {
        private Transform _transform;
        private readonly Vector3 _directionLook = new Vector3(0, 0, 1);
        private void Awake() => _transform = transform;

        public void UpdatePosition(Vector2 position) => _transform.position = new Vector3(position.X, position.Y, 0);
        public void UpdateRotation(Vector2 rotation) => transform.rotation = Quaternion.LookRotation(_directionLook, new Vector3(rotation.X, rotation.Y));
    }
}