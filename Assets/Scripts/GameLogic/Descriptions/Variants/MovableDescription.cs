using System.Numerics;

namespace GameLogic.Descriptions.Variants
{
    public class MovableDescription : ScoreDescription
    {
        public readonly Vector2 InstantVelocity;

        public MovableDescription(string viewKey, int score, float speed) : base(viewKey, score)
        {
            InstantVelocity = new Vector2(speed, 0);
        }
    }
}