using GameLogic.Dependencies.View.Components;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Client.Dependencies.View.Components
{
    public class TransformWrapper : ITransform
    {
        public TransformWrapper(Transform transform) => _transform = transform;

        public Vector2 Up => new Vector2(_transform.up.x, _transform.up.y);

        public Vector2 Position
        {
            get
            {
                var position = _transform.position;
                return new Vector2(position.x, position.y);
            }
            set => _transform.position = new Vector3(value.X, value.Y, 0);
        }

        public void Rotate(float angle) => _transform.Rotate(_rotationVector, angle);

        public float GetRotateAngle()
        {
            _transform.rotation.ToAngleAxis(out var angle, out var axis);
            return axis.z > 0 ? angle * -1 : angle;;
        }


        public Vector2 Scale => new Vector2(_transform.lossyScale.x, _transform.lossyScale.y);

        public float Rotation
        {
            get => _transform.rotation.eulerAngles.z;
            set => _transform.rotation = Quaternion.Euler(new Vector3(0, 0, value));
        }

        private Transform _transform;
        private readonly Vector3 _rotationVector = new Vector3(0, 0, 1);
    }
}