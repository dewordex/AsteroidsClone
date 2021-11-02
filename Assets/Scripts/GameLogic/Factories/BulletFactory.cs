using System.Numerics;
using CustomEcs;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Factories
{
    public class BulletFactory : BaseViewFactory
    {
        public EcsEntity CreateEntity(Vector2 position, Vector2 rotation, Vector2 direction, Vector2 instantVelocity, int score, float lifeTime)
        {
            Add(new VelocityComponent() { InstantVelocity = instantVelocity });
            Add(new BulletComponent());
            Add(new MotionDirectionComponent(){Direction = direction});
            Add(new PositionComponent(){Position =  position});
            Add(new RotationComponent(){RotationDirection =  rotation});
            Add(new ScoreComponent(score));
            Add(new LifeTimeComponent() { Time = lifeTime });

            return Entity;
        }

        public BulletFactory(EcsWorld world, IViewLoader viewLoader) : base(world, viewLoader)
        {
        }
    }
}