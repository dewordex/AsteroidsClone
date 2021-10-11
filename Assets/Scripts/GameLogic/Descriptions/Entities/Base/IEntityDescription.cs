using GameLogic.Dependencies.View;
using Leopotam.Ecs;

namespace GameLogic.Descriptions.Entities.Base
{
    public interface IEntityDescription
    {
        string Key { get; }
        void InstallComponents(EcsEntity ecsEntity, IView view);
    }
}