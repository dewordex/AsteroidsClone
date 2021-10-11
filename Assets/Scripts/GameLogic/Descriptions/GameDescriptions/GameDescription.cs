using System.Collections.Generic;
using Leopotam.Ecs;

namespace GameLogic.Descriptions.GameDescriptions
{
    public abstract class GameDescription
    {
        public void SetupAll(List<EcsSystems> systemsList)
        {
            foreach (var system in systemsList)
            {
                SetupAll(system);
            }
        }
        public virtual void SetupSystems(EcsSystems systems) { }
        public virtual void SetupFixedSystems(EcsSystems systems) { }
        public virtual void SetupLateSystems(EcsSystems systems) { }
        protected virtual void SetupAll(EcsSystems systems) { }
    }
}