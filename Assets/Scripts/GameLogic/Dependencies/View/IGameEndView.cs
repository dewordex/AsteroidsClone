using GameLogic.Dependencies.Base;

namespace GameLogic.Dependencies.View
{
    public interface IGameEndView : IInjectableDependency
    {
        void Show(int score);
    }
}