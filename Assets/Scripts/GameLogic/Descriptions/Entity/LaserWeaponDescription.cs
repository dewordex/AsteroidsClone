namespace GameLogic.Descriptions.Entity
{
    public class LaserWeaponDescription : WeaponDescription
    {
        public readonly int MaxShots;
        public readonly float RecoveryRate;
        public LaserWeaponDescription(float shotDelay, int maxShots, float recoveryRate) : base(shotDelay)
        {
            MaxShots = maxShots;
            RecoveryRate = recoveryRate;
        }
    }
}