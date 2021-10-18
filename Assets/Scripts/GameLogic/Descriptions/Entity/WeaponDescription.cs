using GameLogic.Descriptions.Base;

namespace GameLogic.Descriptions.Entity
{
    public class WeaponDescription : IDescription
    {
        public readonly float ShotDelay;

        public WeaponDescription(float shotDelay) => ShotDelay = shotDelay;
    }
}