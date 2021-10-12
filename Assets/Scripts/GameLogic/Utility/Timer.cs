using System;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Systems;
using Leopotam.Ecs;

namespace GameLogic.Utility
{
    public class Timer<T>
    {
        private EcsWorld _world;
        private IDeltaTime _deltaTime;
        private Action _action;
        private EcsFilter<TimerComponent<T>> _filter;

        public Timer(EcsWorld world, IDeltaTime deltaTime)
        {
            _world = world;
            _deltaTime = deltaTime;
        }

        public void Start(EcsFilter<TimerComponent<T>> filter, Action action, float waitTime)
        {
            _action = action;
            _filter = filter;
            _world.NewEntity().Replace(new TimerComponent<UfoSpawnSystem>() { Time = waitTime });
        }

        public void Update()
        {
            ref var timerComponent = ref _filter.Get1(0);
            timerComponent.Time -= _deltaTime.Value;

            if (timerComponent.Time <= 0)
            {
                timerComponent.Time = 1;
                _action();
            }
        }

        public void Stop()
        {
            foreach (var i in _filter)
            {
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}