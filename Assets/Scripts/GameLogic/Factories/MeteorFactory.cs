using System.Numerics;
using CustomEcs;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Factories
{
    public class MeteorFactory : BaseViewFactory
    {
        public EcsEntity CreateEntity(Vector2 position, Vector2 velocity, Vector2 direction, int score)
        {
            Add(new PositionComponent(){Position = position});
            Add(new VelocityComponent(){InstantVelocity = velocity});
            Add(new MeteorComponent());
            Add(new ScoreComponent(score));
            Add(new MotionDirectionComponent(){Direction = direction});
            return Entity;
        }
        
        public MeteorFactory(EcsWorld world, IViewLoader viewLoader) : base(world, viewLoader)
        {
            
        }
    }
}