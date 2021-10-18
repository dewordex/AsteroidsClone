using GameLogic.Dependencies.Base;

namespace GameLogic.Dependencies.View
{
    public interface IStatsView: IInjectableDependency
    {
        void SetStats(string stats);
    }
}