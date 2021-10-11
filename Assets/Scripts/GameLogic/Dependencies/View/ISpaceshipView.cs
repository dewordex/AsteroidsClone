using GameLogic.Dependencies.View.Components;

namespace GameLogic.Dependencies.View
{
    public interface ISpaceshipView : IView
    {
        ITransform Transform { get; }
    }
}