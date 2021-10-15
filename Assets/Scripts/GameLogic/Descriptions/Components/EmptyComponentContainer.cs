using GameLogic.Dependencies.View;
using GameLogic.Descriptions.Base;

namespace GameLogic.Descriptions.Components
{
    public class EmptyComponentContainer<TView,TDescription> : ComponentsContainer<TView, TDescription > where TView : IView where TDescription : IDescription
    {
        protected override void Setup(TDescription description)
        {
        }
    }

}