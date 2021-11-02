namespace GameLogic.Descriptions.Variants
{
    public class BulletDescription : MovableDescription
    {
        public readonly float LifeTime;

        public BulletDescription(string viewKey, float sizeX, float sizeY, int score, float speed, float lifeTime) : base(viewKey, sizeX, sizeY, score, speed)
        {
            LifeTime = lifeTime;
        }
    }
}