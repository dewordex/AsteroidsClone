using System;
using CustomEcs;
using GameLogic.Components;
using GameLogic.Dependencies.Base;
using GameLogic.Dependencies.View;
using GameLogic.Descriptions.Base;

namespace GameLogic.Descriptions
{
    public class EntityFactory : IEntityFactory, IEntityFactorySettings
    {
        private EcsWorld _world;
        private IViewLoader _viewLoader;
        private EntitiesDescriptionsGenerator _entitiesDescriptionsGenerator;

        public IAsyncOperationHandle<IView> StartCreate<T>(T componentsContainer, string descriptionId) where T : IComponentsContainer
        {
            if (_entitiesDescriptionsGenerator.ComponentsContainers[descriptionId] is IViewDescription description)
            {
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
            else
            {
                throw new Exception("Description is not an IViewDescription");
            }
        }

        public void Init(EcsWorld world, IViewLoader viewLoader, EntitiesDescriptionsGenerator entitiesDescriptionsGenerator)
        {
            _world = world;
            _viewLoader = viewLoader;
            _entitiesDescriptionsGenerator = entitiesDescriptionsGenerator;
        }
    }
}