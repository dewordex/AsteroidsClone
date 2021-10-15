using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Utility;
using Leopotam.Ecs;

namespace GameLogic.Systems.Laser
{
    public class LaserNumbersShotsIncreaseSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<LaserWeaponComponent> _filter;
        private IDeltaTime _deltaTime;
        [EcsIgnoreInject] private Timer _timer;

        public void Run() => _timer.Update(_deltaTime.Value);

        public void Init()
        {
            _timer = new Timer(_filter.Get1(0).RecoveryRate);
            _timer.Elapsed += OnElapsed;
        }

        private void OnElapsed()
        {
            if (_filter.IsEmpty() == false)
            {
                ref var laserWeaponComponent = ref _filter.Get1(0);
                if (laserWeaponComponent.NumberOfShots < laserWeaponComponent.MaxShots)
                    laserWeaponComponent.NumberOfShots++;
            }
        }
    }
}