using System;
using System.Numerics;

namespace GameLogic.Dependencies.View
{
    public interface ILaserView : IView
    {
        void Shoot(Vector2 startPosition, Vector2 direction, float duration);
        event Action<ILaserView> Disabled;
    }
}