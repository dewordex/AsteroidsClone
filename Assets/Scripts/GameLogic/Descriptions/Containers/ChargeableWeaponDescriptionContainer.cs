using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Ids;
using GameLogic.Descriptions.Variants;

namespace GameLogic.Descriptions.Containers
{
    public class ChargeableWeaponDescriptionContainer : DescriptionsContainer<ChargeableWeaponDescription>
    {
        public ChargeableWeaponDescriptionContainer()
        {
            Add(DescriptionIds.LaserWeapon, new ChargeableWeaponDescription(0.5f, 10, 5, 0));
        }
    }
}