namespace GameLogic.Components
{
    public struct ShotDelayComponent
    {
        public readonly float ShotDelay;
        public float CurrentDelay;

        public ShotDelayComponent(float shotDelay)
        {
            ShotDelay = shotDelay;
            CurrentDelay = 0;
        }
    }
}