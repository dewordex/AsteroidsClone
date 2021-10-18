using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;
using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Entity;

namespace GameLogic.Descriptions.Components
{
    public class BulletComponentsContainer : ComponentsContainer<IMovableView, AmmoDescription>
    {
        protected override void Setup(AmmoDescription description)
        {
            AddComponent(new VelocityComponent() { InstantVelocity = description.InstantVelocity });
            AddComponent(new BulletComponent());
            AddComponent(new MotionDirectionComponent());
            AddComponent(new ScoreComponent(10));
            AddComponent(new LifeTimeComponent() { Time = description.LifeTime });
            AddComponent(new Component<ITransform>(View.Transform));
        }
    }

    public struct LifeTimeComponent
    {
        public float Time;
    }
}