using GameLogic.Dependencies;
using UnityEngine;

namespace Client.Dependencies
{
    public class CameraWrapper : MonoBehaviour, ICamera
    {
        private Camera _camera;
        private void Awake() => _camera = GetComponent<Camera>();

        public float OrthographicSize => _camera.orthographicSize;
        public float Aspect => _camera.aspect;
    }
}