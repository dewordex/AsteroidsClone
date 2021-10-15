using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Descriptions.Components;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class LifeTimeSystem : IEcsRunSystem
    {
        private EcsFilter<LifeTimeComponent> _filter;
        private IDeltaTime _deltaTime;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var lifeTimeComponent = ref _filter.Get1(i);

                if (lifeTimeComponent.Time <= 0)
                {
                    _filter.GetEntity(i).Replace(new DeathComponent());
                }
                else
                {
                    lifeTimeComponent.Time -= _deltaTime.Value;
                }
            }
        }
    }
}