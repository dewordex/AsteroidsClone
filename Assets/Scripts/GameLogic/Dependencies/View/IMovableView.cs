using System.Numerics;

namespace GameLogic.Dependencies.View
{
    public interface IMovableView : IView
    {
        void UpdatePosition(Vector2 position);
        void UpdateRotation(Vector2 rotation);
    }
}