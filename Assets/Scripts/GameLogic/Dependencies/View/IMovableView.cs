using GameLogic.Dependencies.View.Components;

namespace GameLogic.Dependencies.View
{
    public interface IMovableView : IView
    {
        ITransform Transform { get; }
    }
}