using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;
using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Entity;

namespace GameLogic.Descriptions.Components
{
    public class UfoComponentsContainer : ComponentsContainer<IMovableView, MovableEntityDescription>
    {
        protected override void Setup(MovableEntityDescription description)
        {
            AddComponent(new Component<ITransform>(View.Transform));
            AddComponent(new VelocityComponent() { InstantVelocity = description.InstantVelocity});
            AddComponent(new MotionDirectionComponent());
            AddComponent(new ScoreComponent(200));
            AddComponent(new UfoComponent());
        }
    }
}