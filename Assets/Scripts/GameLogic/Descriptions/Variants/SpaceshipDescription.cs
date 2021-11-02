namespace GameLogic.Descriptions.Variants
{
    public class SpaceshipDescription : ViewDescription
    {
        public readonly float Acceleration;
        public readonly float Mass;

        public SpaceshipDescription(string viewKey, float acceleration, float mass) : base(viewKey)
        {
            Acceleration = acceleration;
            Mass = mass;
        }
    }
}