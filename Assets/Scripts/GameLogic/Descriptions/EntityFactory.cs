using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Descriptions.Base;
using Leopotam.Ecs;

namespace GameLogic.Descriptions
{
    public class EntityFactory : IEntityFactory, IEntityFactorySettings
    {
        private EcsWorld _world;
        private IViewLoader _viewLoader;
        private EntitiesDescriptionsGenerator _entitiesDescriptionsGenerator;

        public IAsyncOperationHandle<IView> StartCreate<T>(T componentsContainer, string descriptionId) where T : IComponentsContainer
        {
            var description = _entitiesDescriptionsGenerator.ComponentsContainers[descriptionId];
            var asyncOperationHandle = _viewLoader.InstantiateAsync<IView>(description.ViewId);
            asyncOperationHandle.Completed += handle =>
            {
                var entity = _world.NewEntity();
                var view = handle.Result;
                view.EntityLink = entity;
                entity.Replace(new Component<IView>(view));

                componentsContainer.InstallComponents(entity, view, description);
            };

            return asyncOperationHandle;
        }

        public void Init(EcsWorld world, IViewLoader viewLoader, EntitiesDescriptionsGenerator entitiesDescriptionsGenerator)
        {
            _world = world;
            _viewLoader = viewLoader;
            _entitiesDescriptionsGenerator = entitiesDescriptionsGenerator;
        }
    }

    public interface IEntityFactory
    {
        IAsyncOperationHandle<IView> StartCreate<T>(T componentsContainer, string descriptionId) where T : IComponentsContainer;
    }

    public interface IEntityFactorySettings
    {
        void Init(EcsWorld world, IViewLoader viewLoader, EntitiesDescriptionsGenerator entitiesDescriptionsGenerator);
    }
}