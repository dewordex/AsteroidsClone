namespace GameLogic.Descriptions.Entity
{
    public class LaserWeaponDescription : WeaponDescription
    {
        public readonly float MaxShots;
        public readonly float RecoveryRate;
        public LaserWeaponDescription(float shotDelay, float maxShots, float recoveryRate) : base(shotDelay)
        {
            MaxShots = maxShots;
            RecoveryRate = recoveryRate;
        }
    }
}