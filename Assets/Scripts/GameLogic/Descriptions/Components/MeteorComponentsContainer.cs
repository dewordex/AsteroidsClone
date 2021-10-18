using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;
using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Entity;

namespace GameLogic.Descriptions.Components
{
    public class MeteorComponentsContainer : ComponentsContainer<IMovableView, MeteorDescription>
    {
        protected override void Setup(MeteorDescription description)
        {
            AddComponent(new VelocityComponent());
            AddComponent(new MeteorComponent());
            AddComponent(new ScoreComponent(200));
            AddComponent(new MotionDirectionComponent());
            AddComponent(new Component<ITransform>(View.Transform));
        }
    }
}