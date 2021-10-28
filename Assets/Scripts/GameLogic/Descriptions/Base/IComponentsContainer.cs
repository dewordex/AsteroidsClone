using CustomEcs;
using GameLogic.Dependencies.View;

namespace GameLogic.Descriptions.Base
{
    public interface IComponentsContainer
    {
        void InstallComponents(EcsEntity entity, IView view, IDescription description);
    }
}