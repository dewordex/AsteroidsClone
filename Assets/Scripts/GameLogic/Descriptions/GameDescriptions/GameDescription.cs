using System.Collections.Generic;
using CustomEcs.Systems;

namespace GameLogic.Descriptions.GameDescriptions
{
    public abstract class GameDescription
    {
        public void SetupAll(List<EcsSystem> systemsList)
        {
            foreach (var system in systemsList)
            {
                SetupAll(system);
            }
        }
        public virtual void SetupSystems(EcsSystem systems) { }
        public virtual void SetupFixedSystems(EcsSystem systems) { }
        public virtual void SetupLateSystems(EcsSystem systems) { }
        protected virtual void SetupAll(EcsSystem systems) { }
    }
}