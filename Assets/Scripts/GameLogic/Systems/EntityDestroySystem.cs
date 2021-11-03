using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Systems
{
    public class EntityDestroySystem : IEcsRunSystem
    {
        private Group<DeathComponent, ViewComponentRef<IView>> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var view = _filter.Get2(i).View;
                view.Destroy();
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}