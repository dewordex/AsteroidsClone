using GameLogic.Descriptions.Settings;
using GameLogic.Systems;
using GameLogic.Systems.Spaceship;
using GameLogic.Systems.Spaceship.Movement;
using Leopotam.Ecs;

namespace GameLogic.Descriptions.GameDescriptions
{
    public class ReleaseGameDescription : GameDescription
    {
        protected override void SetupAll(EcsSystems systems)
        {
            systems.Inject(new AsteroidsSpawnSetting(20, 600, 4));
        }

        public override void SetupSystems(EcsSystems systems)
        {
            systems.Add(new TimeSessionSystem());
            systems.Add(new AsteroidsSpawnSystem());
            systems.Add(new SpaceshipSpawnSystem());
            systems.Add(new SpaceshipVelocitySystem());
            systems.Add(new SpaceshipRotateSystem());
            systems.Add(new SpaceshipMovementSystem());
            systems.Add(new AsteroidsDirectionSystem());
            systems.Add(new MovementInDirectionSystem());
        }
    }
}