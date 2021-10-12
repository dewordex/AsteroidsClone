using System.Numerics;

namespace GameLogic.Dependencies
{
    public interface IRandom
    {
        Vector2 GetRandomPointOnCircle(int radius);
        Vector2 GetRandomPositionOutsideCamera(float offset, float cameraOrthographicSize, float cameraAspect);
        Vector2 GetRandomPositionInsideCamera(float cameraOrthographicSize, float cameraAspect);
        float Range(float min, float max);
    }
}