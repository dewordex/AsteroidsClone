namespace GameLogic.Descriptions.Variants
{
    public class LaserDescription : ViewDescription
    {
        public readonly float Duration;
        public LaserDescription(string viewKey, float duration) : base(viewKey)
        {
            Duration = duration;
        }
    }
}