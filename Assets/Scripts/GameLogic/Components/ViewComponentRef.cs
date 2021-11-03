using GameLogic.Dependencies.View;

namespace GameLogic.Components
{
    public readonly struct ViewComponentRef<T> where T: IView
    {
        public readonly T View;
        public ViewComponentRef(T view) => View = view;
    }
}