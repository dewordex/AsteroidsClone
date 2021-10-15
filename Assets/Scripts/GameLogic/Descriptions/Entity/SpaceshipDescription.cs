using GameLogic.Descriptions.Base;

namespace GameLogic.Descriptions.Entity
{
    public class SpaceshipDescription : IViewDescription
    {
        public string ViewId { get; }
        public readonly float Acceleration;
        public readonly float Mass;
        public SpaceshipDescription(string viewId, float acceleration, float mass)
        {
            ViewId = viewId;
            Acceleration = acceleration;
            Mass = mass;
        }
    }
}