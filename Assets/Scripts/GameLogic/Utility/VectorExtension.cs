using System;
using System.Numerics;

namespace GameLogic.Utility
{
    public static class VectorExtension
    {
        private const float Deg2Rad = 0.01745329f;
        public static Vector2 Rotate(this Vector2 vector, float angle)
        {
            var radians = angle * Deg2Rad;
            var ca = (float)Math.Cos(radians);
            var sa = (float)Math.Sin(radians);
            return new Vector2(ca * vector.X - sa * vector.Y, sa * vector.X + ca * vector.Y);
        }
    }
}