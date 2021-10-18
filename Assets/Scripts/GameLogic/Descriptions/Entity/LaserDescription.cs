using GameLogic.Descriptions.Base;

namespace GameLogic.Descriptions.Entity
{
    public class LaserDescription : IViewDescription
    {
        public string ViewId { get; }
        public float Duration;

        public LaserDescription(string viewId, float duration)
        {
            Duration = duration;
            ViewId = viewId;
        }
    }
}