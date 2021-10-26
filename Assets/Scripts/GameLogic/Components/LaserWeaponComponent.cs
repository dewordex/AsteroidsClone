namespace GameLogic.Components
{
    public struct LaserWeaponComponent
    {
        public readonly int MaxShots;
        public readonly float RecoveryRate;
        public readonly float ShootDelay;
        public int NumberOfShots;


        public LaserWeaponComponent(int maxShots, float recoveryRate, int numberOfShots, float shootDelay)
        {
            MaxShots = maxShots;
            RecoveryRate = recoveryRate;
            NumberOfShots = numberOfShots;
            ShootDelay = shootDelay;
        }
    }
}