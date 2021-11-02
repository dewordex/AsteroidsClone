using System.Numerics;
using CustomEcs;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Factories
{
    public class SpaceshipFactory : BaseViewFactory
    {
        public EcsEntity CreateEntity(float acceleration, float mass, Vector2 size)
        {
            Add(new VelocityComponent());
            Add(new RigidbodyComponent() { Acceleration = acceleration, Mass = mass });
            Add(new PlayerComponent());
            Add(new PositionComponent());
            Add(new RotationComponent() { RotationDirection = new Vector2(0, 1) });
            Add(new StatsComponent());
            Add(new TeleportationSizeComponent(size));
            return Entity;
        }

        public SpaceshipFactory(EcsWorld world, IViewLoader viewLoader) : base(world, viewLoader)
        {
        }
    }
}