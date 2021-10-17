﻿using GameLogic.Descriptions.Settings;
using GameLogic.Systems;
using GameLogic.Systems.Asteroid;
using GameLogic.Systems.Laser;
using GameLogic.Systems.Spaceship;
using GameLogic.Systems.Spaceship.Movement;
using GameLogic.Systems.Teleportation;
using Leopotam.Ecs;

namespace GameLogic.Descriptions.GameDescriptions
{
    public class ReleaseGameDescription : GameDescription
    {
        protected override void SetupAll(EcsSystems systems)
        {
            systems.Inject(new AsteroidsSpawnSetting(20, 600, 4));
            systems.Inject(new UfoSpawnSetting((20,60)));
            systems.Inject(new EntityFactory());
            systems.Inject(new EntitiesDescriptionsGenerator());
        }

        public override void SetupSystems(EcsSystems systems)
        {
            systems.Add(new EntityFactoryInstallSystem());
            systems.Add(new BulletSpawnSystem());
            systems.Add(new LaserWeaponInitSystem());
            systems.Add(new LaserShotEmitterSystem());
            systems.Add(new LaserSpawnSystem());
            systems.Add(new LaserNumbersShotsIncreaseSystem());
            systems.Add(new ShootDelaySystem());
            systems.Add(new TimeSessionSystem());
            systems.Add(new AsteroidsSpawnSystem());
            systems.Add(new UfoSpawnSystem());
            systems.Add(new UfoDirectionSystem());
            systems.Add(new SpaceshipSpawnSystem());
            systems.Add(new SpaceshipVelocitySystem());
            systems.Add(new SpaceshipRotateSystem());
            systems.Add(new SpaceshipMovementSystem());
            systems.Add(new AsteroidsDirectionSystem());
            systems.Add(new MovementInDirectionSystem());
            systems.Add(new AmmoCollisionSystem());
            systems.Add(new TeleportationSystem());
            systems.Add(new LifeTimeSystem());
            systems.Add(new SpaceshipDeathSystem());
            systems.Add(new AsteroidDeathSystem());
            systems.Add(new EntityDestroySystem());

        }
    }
}