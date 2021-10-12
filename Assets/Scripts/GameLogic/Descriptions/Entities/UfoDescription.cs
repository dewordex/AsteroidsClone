using System.Numerics;
using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;
using GameLogic.Descriptions.Entities.Base;

namespace GameLogic.Descriptions.Entities
{
    public class UfoDescription : EntityDescription<IMovableView>
    {
        public override string Key => "ufo";

        protected override void SetupComponents()
        {
            AddComponent(new Component<ITransform>(View.Transform));
            AddComponent(new VelocityComponent() { InstantVelocity = new Vector2(3, 0) });
            AddComponent(new MotionDirectionComponent());
            AddComponent(new UfoComponent());
        }
    }
}