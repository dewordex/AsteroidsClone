using System.Numerics;
using GameLogic.Descriptions.Base;

namespace GameLogic.Descriptions.Entity
{
    public class MovableEntityDescription : IDescription
    {
        public string ViewId { get; }
        public readonly Vector2 InstantVelocity;

        public MovableEntityDescription(string viewId, Vector2 instantVelocity)
        {
            InstantVelocity = instantVelocity;
            ViewId = viewId;
        }
    }
}