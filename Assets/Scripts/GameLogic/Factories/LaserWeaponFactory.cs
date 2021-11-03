using CustomEcs;
using GameLogic.Components;

namespace GameLogic.Factories
{
    public class LaserWeaponFactory : BaseFactory
    {
        public EcsEntity CreateEntity(float shotDelay, int maxShots, float recoveryRate, int numberOfShots)
        {
            Add(new LaserWeaponComponent(maxShots, recoveryRate, numberOfShots, shotDelay));
            Add(new ShotDelayComponent());
            return Entity;
        }

        
        public LaserWeaponFactory(EcsWorld world) : base(world)
        {
            
        }
    }
}