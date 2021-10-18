using System;
using GameLogic.Dependencies;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = System.Numerics.Vector2;

namespace Client.Dependencies
{
    public class CustomRandom : IRandom
    {
        public Vector2 GetRandomPointOnCircle(int radius)
        {
            float randomAngle = Random.Range(0f, 2 * Mathf.PI - float.Epsilon);
            Vector2 pointOnCircle = new Vector2((float)Math.Cos(randomAngle), (float)Math.Sin(randomAngle)) * radius;
            return pointOnCircle;
        }

        public Vector2 GetRandomPositionOutsideCamera(float offset, float cameraOrthographicSize, float cameraAspect)
        {
            var randomPointOnCircle = GetRandomPointOnCircle(1);
            return Math.Abs(randomPointOnCircle.X) > Math.Abs(randomPointOnCircle.Y)
                ? new Vector2(Math.Sign(randomPointOnCircle.X) * (cameraOrthographicSize * cameraAspect + offset + 1), randomPointOnCircle.Y * cameraOrthographicSize)
                : new Vector2(randomPointOnCircle.X * cameraOrthographicSize * cameraAspect, Math.Sign(randomPointOnCircle.Y) * (cameraOrthographicSize + offset + 1));
        }

        public Vector2 GetRandomPositionInsideCamera(float cameraOrthographicSize, float cameraAspect)
        {
            var x = Random.Range(-cameraOrthographicSize * cameraAspect, cameraOrthographicSize * cameraAspect);
            var y = Random.Range(-cameraOrthographicSize, cameraOrthographicSize);
            return new Vector2(x, y);
        }

        public float Range(float min, float max) => Random.Range(min, max);
    }
}