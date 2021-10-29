using GameLogic.Dependencies.View;
using GameLogic.Descriptions.Base;

namespace GameLogic.Dependencies.Base
{
    public interface IEntityFactory
    {
        IAsyncOperationHandle<IView> StartCreate<T>(T componentsContainer, string descriptionId) where T : IComponentsContainer;
    }
}