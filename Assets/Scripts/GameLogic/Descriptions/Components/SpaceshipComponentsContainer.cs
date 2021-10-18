using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;
using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Entity;

namespace GameLogic.Descriptions.Components
{
    public class SpaceshipComponentsContainer : ComponentsContainer<IMovableView, SpaceshipDescription>
    {
        protected override void Setup(SpaceshipDescription description)
        {
            AddComponent(new Component<ITransform>(View.Transform));
            AddComponent(new VelocityComponent());
            AddComponent(new RigidbodyComponent() { Acceleration = description.Acceleration, Mass = description.Mass });
            AddComponent(new PlayerComponent());
            AddComponent(new StatsComponent());
        }
    }
}