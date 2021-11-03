using CustomEcs;
using GameLogic.Components;

namespace GameLogic.Factories
{
    public class BulletWeaponFactory : BaseFactory
    {
        public EcsEntity CreateEntity(float shotDelay)
        {
            Add(new ShotDelayComponent(shotDelay));
            Add(new BulletWeaponComponent());
            return Entity;
        }

        public BulletWeaponFactory(EcsWorld world) : base(world)
        {
        }
    }
}