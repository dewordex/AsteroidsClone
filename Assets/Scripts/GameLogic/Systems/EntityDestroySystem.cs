using GameLogic.Components;
using GameLogic.Dependencies.View;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class EntityDestroySystem : IEcsRunSystem
    {
        private EcsFilter<DeathComponent, Component<IView>> _filter; 
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var view = ref _filter.Get2(i).Value;
                view.Destroy();
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}