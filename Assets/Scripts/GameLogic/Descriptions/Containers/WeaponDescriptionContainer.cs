using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Ids;
using GameLogic.Descriptions.Variants;

namespace GameLogic.Descriptions.Containers
{
    public class WeaponDescriptionContainer : DescriptionsContainer<WeaponDescription>
    {
        public WeaponDescriptionContainer()
        {
            Add(DescriptionIds.BulletWeapon, new WeaponDescription(0.25f));
        }
    }
}