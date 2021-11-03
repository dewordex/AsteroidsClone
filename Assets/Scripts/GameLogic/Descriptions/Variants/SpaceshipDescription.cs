namespace GameLogic.Descriptions.Variants
{
    public class SpaceshipDescription : ViewDescription
    {
        public readonly float Acceleration;
        public readonly float Mass;

        public SpaceshipDescription(string viewKey, float sizeX, float sizeY, float acceleration, float mass) : base(viewKey, sizeX, sizeY)
        {
            Acceleration = acceleration;
            Mass = mass;
        }
    }
}