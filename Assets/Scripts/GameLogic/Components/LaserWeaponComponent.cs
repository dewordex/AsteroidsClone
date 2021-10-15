namespace GameLogic.Components
{
    public struct LaserWeaponComponent
    {
        public readonly float MaxShots;
        public readonly float RecoveryRate;
        public readonly float ShootDelay;
        public float NumberOfShots;
        

        public LaserWeaponComponent(float maxShots, float recoveryRate, float numberOfShots, float shootDelay)
        {
            MaxShots = maxShots;
            RecoveryRate = recoveryRate;
            NumberOfShots = numberOfShots;
            ShootDelay = shootDelay;
        }
    }
}