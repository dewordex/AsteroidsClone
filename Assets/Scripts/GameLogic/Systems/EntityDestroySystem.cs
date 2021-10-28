using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Systems
{
    public class EntityDestroySystem : IEcsRunSystem
    {
        private Group<DeathComponent, Component<IView>> _filter; 
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