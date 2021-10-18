using GameLogic.Descriptions.Base;

namespace GameLogic.Descriptions.Entity
{
    public class MeteorDescription : IViewDescription
    {
        public string ViewId { get; }
        public readonly float MultiplierSpeed;

        public MeteorDescription(string viewId, float multiplierSpeed)
        {
            ViewId = viewId;
            MultiplierSpeed = multiplierSpeed;
        }
    }
}