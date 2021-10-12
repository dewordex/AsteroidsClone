using GameLogic.Dependencies.View.Components;

namespace GameLogic.Dependencies.View
{
    public interface IAsteroidView : IView
    {
        ITransform Transform { get; }
    }
}