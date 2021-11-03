using CustomEcs;
using CustomEcs.Systems;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Ids;
using GameLogic.Factories;

namespace GameLogic.Systems.Laser
{
    public class LaserWeaponInitSystem : IEcsInitSystem
    {
        private DescriptionsContainer _descriptionsContainer;
        private FactoriesContainer _factoriesContainer;
        private EcsWorld _world;

        public void Init()
        {
            var description = _descriptionsContainer.ChargeableWeaponDescriptionsContainer.Get(DescriptionIds.LaserWeapon);
            _factoriesContainer.GetLaserWeaponFactory().CreateEntity(description.ShotDelay, description.MaxShots, description.RecoveryRate, description.StartNumberOfShots);
        }
    }
}