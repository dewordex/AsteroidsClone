namespace GameLogic.Descriptions.Variants
{
    public class BulletDescription : MovableDescription
    {
        public readonly float LifeTime;

        public BulletDescription(string viewKey, int score, float speed, float lifeTime) : base(viewKey, score, speed)
        {
            LifeTime = lifeTime;
        }
    }
}