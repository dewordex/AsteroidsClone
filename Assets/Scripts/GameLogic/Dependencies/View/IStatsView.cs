using GameLogic.Dependencies.Base;

namespace GameLogic.Dependencies.View
{
    public interface IStatsView: IInjectableDependency
    {
        void UpdateSpeed(string speed);
        void UpdatePosition(string x, string y);
        void UpdateAngle(string angle);
        void UpdateLaserCount(string currentCount, string maxCount);
        void SetLaserTime(string time);
    }
}