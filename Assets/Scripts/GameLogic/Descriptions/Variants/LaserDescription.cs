namespace GameLogic.Descriptions.Variants
{
    public class LaserDescription : ViewDescription
    {
        public readonly float Duration;

        public LaserDescription(string viewKey, float sizeX, float sizeY, float duration) : base(viewKey, sizeX, sizeY)
        {
            Duration = duration;
        }
    }
}
