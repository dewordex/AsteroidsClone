using GameLogic.Components;
using GameLogic.Dependencies.View;
using Leopotam.Ecs;

namespace GameLogic.Descriptions.Entities.Base
{
    public abstract class EntityDescription<T> : IEntityDescription where T : IView
    {
        public abstract string Key { get; }
        protected T View { get; private set; }
        private EcsEntity _ecsEntity;

        public void InstallComponents(EcsEntity ecsEntity, IView view)
        {
            _ecsEntity = ecsEntity;
            View  = (T) view;
            _ecsEntity.Replace(new Component<IView>(view));
            SetupComponents();
        }

        protected abstract void SetupComponents();

        protected void AddComponent<TD>(TD component) where TD : struct => _ecsEntity.Replace(component);
    }
}