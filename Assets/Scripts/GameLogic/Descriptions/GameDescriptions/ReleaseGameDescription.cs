using CustomEcs;
using CustomEcs.Systems;
using GameLogic.Dependencies.View;
using GameLogic.Factories;
using GameLogic.Systems;
using GameLogic.Systems.Asteroid;
using GameLogic.Systems.Bullet;
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
        private IViewLoader _viewLoader;
        public ReleaseGameDescription(IViewLoader viewLoader) => _viewLoader = viewLoader;

        protected override void SetupAll(EcsSystem systems, EcsWorld world)
        {
            systems.Inject(new FactoriesContainer(world, _viewLoader));
            systems.Inject(new DescriptionsContainer());
        }

        public override void SetupSystems(EcsSystem systems)
        {
            BulletSystemsSetup(systems);
            LaserSystemsSetup(systems);
            systems.Add(new ShootDelaySystem());
            systems.Add(new TimeSessionSystem());
            AsteroidSystemsSetup(systems);
            UfoSystemsSetup(systems);
            SpaceShipSystemsSetup(systems);
            systems.Add(new MovementInDirectionSystem());
            systems.Add(new CollisionSystem());
            systems.Add(new TeleportationSystem());
            systems.Add(new LifeTimeSystem());
            systems.Add(new AsteroidSeparationSystem());
            systems.Add(new MeteorSpawnSystem());
            TransformViewSystemsSetup(systems);
            StatsSystemsSetup(systems);
            systems.Add(new AsteroidDeathSystem());
            systems.Add(new ScoreSystem());
            systems.Add(new GameEndSystem());
            systems.Add(new EntityDestroySystem());
        }

        private void TransformViewSystemsSetup(EcsSystem systems)
        {
            systems.Add(new UpdateRotationViewSystem());
            systems.Add(new UpdatePositionViewSystem());
        }

        private void AsteroidSystemsSetup(EcsSystem systems)
        {
            systems.Add(new AsteroidsSpawnSystem());
            systems.Add(new AsteroidsDirectionSystem());
        }

        private void BulletSystemsSetup(EcsSystem systems)
        {
            systems.Add(new BulletWeaponInitSystem());
            systems.Add(new BulletSpawnSystem());
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