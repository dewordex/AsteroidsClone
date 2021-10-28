using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;
using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Entity;

namespace GameLogic.Descriptions.Components
{
    public class AsteroidComponentsContainer : ComponentsContainer<IMovableView, MovableEntityDescription>
    {
        protected override void Setup(MovableEntityDescription description)
        {
            AddComponent(new VelocityComponent() { InstantVelocity = description.InstantVelocity });
            AddComponent(new AsteroidComponent());
            AddComponent(new MotionDirectionComponent());
            AddComponent(new ScoreComponent(100));
            AddComponent(new SetupDirectionComponent());
            AddComponent(new Component<ITransform>(View.Transform));
        }
    }
}