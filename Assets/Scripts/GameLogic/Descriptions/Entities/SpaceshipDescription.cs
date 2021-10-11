using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;
using GameLogic.Descriptions.Entities.Base;

namespace GameLogic.Descriptions.Entities
{
    public class SpaceshipDescription : EntityDescription<ISpaceshipView>
    {
        public override string Key => "spaceship";

        protected override void SetupComponents()
        {
            AddComponent(new Component<ITransform>(View.Transform));
            AddComponent(new VelocityComponent());
            AddComponent(new RigidbodyComponent() { Acceleration = 10, Mass = 3 });
            AddComponent(new PlayerComponent());
        }
    }
}