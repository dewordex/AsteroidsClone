using System.Numerics;
using CustomEcs;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Factories
{
    public class UfoFactory : BaseViewFactory
    {
        public EcsEntity CreateEntity(Vector2 position, Vector2 instantVelocity, int score)
        {
            Add(new VelocityComponent() { InstantVelocity = instantVelocity });
            Add(new MotionDirectionComponent());
            Add(new ScoreComponent(score));
            Add(new PositionComponent() { Position = position });
            Add(new UfoComponent());

            return Entity;
        }


        public UfoFactory(EcsWorld world, IViewLoader viewLoader) : base(world, viewLoader)
        {
        }
    }
}