using CustomEcs.Systems;
using GameLogic.Descriptions.Settings;
using GameLogic.Systems;
using GameLogic.Systems.Asteroid;
using GameLogic.Systems.Laser;
using GameLogic.Systems.Meteor;
using GameLogic.Systems.Spaceship;
using GameLogic.Systems.Spaceship.Movement;
using GameLogic.Systems.Stats;
using GameLogic.Systems.Teleportation;

namespace GameLogic.Descriptions.GameDescriptions
{
    public class ReleaseGameDescription : GameDescription
    {
        protected override void SetupAll(EcsSystem systems)
        {
            systems.Inject(new AsteroidsSpawnSetting(40, 600, 4));
            systems.Inject(new UfoSpawnSetting((5, 20)));
            systems.Inject(new EntityFactory());
            systems.Inject(new EntitiesDescriptionsGenerator());
        }

        public override void SetupSystems(EcsSystem systems)
        {
            systems.Add(new EntityFactoryInstallSystem());
            systems.Add(new BulletSpawnSystem());
            LaserSystemsSetup(systems);
            systems.Add(new ShootDelaySystem());
            systems.Add(new TimeSessionSystem());
            systems.Add(new AsteroidsSpawnSystem());
            UfoSystemsSetup(systems);
            SpaceShipSystemsSetup(systems);
            systems.Add(new AsteroidsDirectionSystem());
            systems.Add(new MovementInDirectionSystem());
            systems.Add(new CollisionSystem());
            systems.Add(new TeleportationSystem());
            systems.Add(new LifeTimeSystem());
            systems.Add(new AsteroidSeparationSystem());
            systems.Add(new MeteorSpawnSystem());
            StatsSystemsSetup(systems);
            systems.Add(new AsteroidDeathSystem());
            systems.Add(new ScoreSystem());
            systems.Add(new GameEndSystem());
            systems.Add(new EntityDestroySystem());
        }

        private void StatsSystemsSetup(EcsSystem systems)
        {
            systems.Add(new VelocityStatsSystem());
            systems.Add(new PositionStatsSystem());
            systems.Add(new AngleStatsSystem());
            systems.Add(new LaserStatsSystem());
        }

        private void SpaceShipSystemsSetup(EcsSystem systems)
        {
            systems.Add(new SpaceshipSpawnSystem());
            systems.Add(new SpaceshipVelocitySystem());
            systems.Add(new SpaceshipRotateSystem());
            systems.Add(new SpaceshipMovementSystem());
        }

        private void UfoSystemsSetup(EcsSystem systems)
        {
            systems.Add(new UfoSpawnSystem());
            systems.Add(new UfoDirectionSystem());
        }

        private void LaserSystemsSetup(EcsSystem systems)
        {
            systems.Add(new LaserWeaponInitSystem());
            systems.Add(new LaserShotEmitterSystem());
            systems.Add(new LaserSpawnSystem());
            systems.Add(new LaserNumbersShotsIncreaseSystem());
        }
    }
}