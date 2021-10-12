using GameLogic.Systems;
using GameLogic.Systems.Spaceship;
using GameLogic.Systems.Spaceship.Movement;
using Leopotam.Ecs;

namespace GameLogic.Descriptions.GameDescriptions
{
    public class ReleaseGameDescription : GameDescription
    {
        protected override void SetupAll(EcsSystems systems) { }

        public override void SetupSystems(EcsSystems systems)
        {
            systems.Add(new TimeSessionSystem());
            systems.Add(new SpaceshipSpawnSystem());
            systems.Add(new SpaceshipVelocitySystem());
            systems.Add(new SpaceshipRotateSystem());
            systems.Add(new SpaceshipMovementSystem());
        }
    }
}