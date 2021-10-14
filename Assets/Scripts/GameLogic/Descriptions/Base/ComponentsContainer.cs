using System;
using GameLogic.Dependencies.View;
using Leopotam.Ecs;

namespace GameLogic.Descriptions.Base
{
    public abstract class ComponentsContainer<TView, TDescription> : IComponentsContainer where TView : IView where TDescription : IDescription
    {
        public EcsEntity EcsEntity { get; private set; }
        public TView View { get; private set; }

        public void InstallComponents(EcsEntity entity, IView view, IDescription description)
        {
            View = (TView)view;
            EcsEntity = entity;
            if (description is TDescription cDescription)
                Setup(cDescription);
            else
                throw new Exception($"{typeof(TDescription)} was expected, but {description.GetType()} was received");
        }

        protected abstract void Setup(TDescription description);
        protected void AddComponent<TD>(TD component) where TD : struct => EcsEntity.Replace(component);
    }
}