using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Descriptions.Components;

namespace GameLogic.Systems
{
    public class LifeTimeSystem : IEcsRunSystem
    {
        private Group<LifeTimeComponent> _filter;
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