using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;
using GameLogic.Descriptions.Entities.Base;

namespace GameLogic.Descriptions.Entities
{
    public class AsteroidDescription : EntityDescription<IAsteroidView>
    {
        public override string Key => "asteroid";
        protected override void SetupComponents()
        {
            AddComponent(new VelocityComponent());
            AddComponent(new AsteroidComponent());
            AddComponent(new Component<ITransform>(View.Transform));
        }
    }
}