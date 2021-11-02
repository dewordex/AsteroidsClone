using System.Numerics;

namespace GameLogic.Descriptions.Variants
{
    public class MovableDescription : ScoreDescription
    {
        public readonly Vector2 InstantVelocity;

        public MovableDescription(string viewKey, float sizeX, float sizeY, int score, float speed) : base(viewKey, sizeX, sizeY, score)
        {
            InstantVelocity = new Vector2(speed, 0);
        }
    }
}