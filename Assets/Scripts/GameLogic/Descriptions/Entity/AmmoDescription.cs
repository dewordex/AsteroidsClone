using System.Numerics;

namespace GameLogic.Descriptions.Entity
{
    public class AmmoDescription : MovableEntityDescription
    {
        public readonly float LifeTime;

        public AmmoDescription(string viewId, Vector2 instantVelocity, float lifeTime) : base(viewId, instantVelocity) => LifeTime = lifeTime;
    }
}