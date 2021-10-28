using CustomEcs;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;

namespace GameLogic.Systems
{
    public class TimeSessionSystem : IEcsInitSystem, IEcsRunSystem
    {
        private Group<TimeSessionComponent> _filter;
        private EcsWorld _world;
        private IDeltaTime _deltaTime;

        public void Init() => _world.NewEntity().Replace(new TimeSessionComponent());

        public void Run()
        {
            if (_filter.IsEmpty == false)
            {
                ref var timeSessionComponent = ref _filter.Get1(0);
                timeSessionComponent.Time += _deltaTime.Value;
            }
        }
    }
}