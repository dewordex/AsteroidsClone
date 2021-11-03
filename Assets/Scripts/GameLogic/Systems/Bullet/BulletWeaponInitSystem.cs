using CustomEcs.Systems;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Ids;
using GameLogic.Factories;

namespace GameLogic.Systems.Bullet
{
    public class BulletWeaponInitSystem : IEcsInitSystem
    {
        private DescriptionsContainer _descriptionsContainer;
        private FactoriesContainer _factoriesContainer;
        public void Init()
        {
            var weaponDescription = _descriptionsContainer.BaseWeaponDescriptionsContainer.Get(DescriptionIds.BulletWeapon);
            _factoriesContainer.GetBulletWeaponFactory().CreateEntity(weaponDescription.ShotDelay);
        }
    }
}