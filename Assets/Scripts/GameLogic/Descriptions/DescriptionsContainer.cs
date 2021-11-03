using GameLogic.Descriptions.Containers;

namespace GameLogic.Descriptions
{
    public class DescriptionsContainer
    {
        public readonly MovableDescriptionContainer MovableDescriptionsContainer = new MovableDescriptionContainer();
        public readonly ScoreDescriptionContainer ScoreDescriptionsContainer = new ScoreDescriptionContainer();
        public readonly BulletDescriptionContainer BulletDescriptionsContainer = new BulletDescriptionContainer();
        public readonly SpaceshipDescriptionContainer SpaceshipDescriptionsContainer = new SpaceshipDescriptionContainer();
        public readonly WeaponDescriptionContainer BaseWeaponDescriptionsContainer = new WeaponDescriptionContainer();
        public readonly ChargeableWeaponDescriptionContainer ChargeableWeaponDescriptionsContainer = new ChargeableWeaponDescriptionContainer();
        public readonly LaserDescriptionContainer LaserDescriptionContainer = new LaserDescriptionContainer();
        public readonly AsteroidSpawnDescriptionContainer AsteroidSpawnDescriptionContainer = new AsteroidSpawnDescriptionContainer();
        public readonly UfoSpawnDescriptionContainer UfoSpawnDescriptionContainer = new UfoSpawnDescriptionContainer();
    }
}