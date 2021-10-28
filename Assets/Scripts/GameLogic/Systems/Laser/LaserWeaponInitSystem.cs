using CustomEcs;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Entity;
using GameLogic.Descriptions.Ids;

namespace GameLogic.Systems.Laser
{
    public class LaserWeaponInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private EntitiesDescriptionsGenerator _entitiesDescriptionsGenerator;

        public void Init()
        {
            var laserWeaponDescription = (LaserWeaponDescription)_entitiesDescriptionsGenerator.ComponentsContainers[DescriptionIds.LaserWeapon];
            var newEntity = _world.NewEntity();
            newEntity.Replace(new LaserWeaponComponent(laserWeaponDescription.MaxShots, laserWeaponDescription.RecoveryRate, laserWeaponDescription.MaxShots, laserWeaponDescription.ShotDelay));
            newEntity.Replace(new ShotDelayComponent() { Delay = 0 });
        }
    }
}