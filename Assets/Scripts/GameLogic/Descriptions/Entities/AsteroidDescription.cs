using System.Numerics;
using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;
using GameLogic.Descriptions.Entities.Base;

namespace GameLogic.Descriptions.Entities
{
    public class AsteroidDescription : EntityDescription<IMovableView>
    {
        public override string Key => "asteroid";
        protected override void SetupComponents()
        {
            AddComponent(new VelocityComponent(){InstantVelocity = new Vector2(2,0)});
            AddComponent(new AsteroidComponent());
            AddComponent(new MotionDirectionComponent());
            AddComponent(new Component<ITransform>(View.Transform));
        }
    }
}