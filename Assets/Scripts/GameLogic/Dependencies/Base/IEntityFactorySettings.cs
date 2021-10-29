using CustomEcs;
using GameLogic.Dependencies.View;
using GameLogic.Descriptions;

namespace GameLogic.Dependencies.Base
{
    public interface IEntityFactorySettings
    {
        void Init(EcsWorld world, IViewLoader viewLoader, EntitiesDescriptionsGenerator entitiesDescriptionsGenerator);
    }
}