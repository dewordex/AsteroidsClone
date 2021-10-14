using GameLogic.Dependencies.View;
using Leopotam.Ecs;

namespace GameLogic.Descriptions.Base
{
    public interface IComponentsContainer
    {
        void InstallComponents(EcsEntity entity, IView view, IDescription description);
    }
}