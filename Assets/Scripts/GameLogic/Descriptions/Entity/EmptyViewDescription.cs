using GameLogic.Descriptions.Base;

namespace GameLogic.Descriptions.Entity
{
    public class EmptyViewDescription : IViewDescription
    {
        public string ViewId { get; }

        public EmptyViewDescription(string viewId)
        {
            ViewId = viewId;
        }
    }
}