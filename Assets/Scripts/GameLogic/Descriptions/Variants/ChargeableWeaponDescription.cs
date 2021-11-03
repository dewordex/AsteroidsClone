namespace GameLogic.Descriptions.Variants
{
    public class ChargeableWeaponDescription : WeaponDescription
    {
        public readonly int MaxShots;
        public readonly float RecoveryRate;
        public readonly int StartNumberOfShots;

        public ChargeableWeaponDescription(float shotDelay, int maxShots, float recoveryRate, int startNumberOfShots) : base(shotDelay)
        {
            MaxShots = maxShots;
            RecoveryRate = recoveryRate;
            StartNumberOfShots = startNumberOfShots;
        }
    }
}