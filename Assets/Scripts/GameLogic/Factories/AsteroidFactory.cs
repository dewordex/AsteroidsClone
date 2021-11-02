using System.Numerics;
using CustomEcs;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Factories
{
    public class AsteroidFactory : BaseViewFactory
    {
        public EcsEntity CreateEntity(Vector2 position,Vector2 instantVelocity, int score, Vector2 size)
        {
            Add(new VelocityComponent() { InstantVelocity = instantVelocity });
            Add(new AsteroidComponent());
            Add(new MotionDirectionComponent());
            Add(new ScoreComponent(score));
            Add(new SetupDirectionComponent());
            Add(new PositionComponent(){Position = position});
            Add(new TeleportationSizeComponent(size));
            return Entity;
        }


        public AsteroidFactory(EcsWorld world, IViewLoader viewLoader) : base(world, viewLoader)
        {
        }
    }
}