using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Systems.Stats
{
    public class LaserStatsSystem : IEcsRunSystem, IEcsInitSystem
    {
        private Group<LaserWeaponComponent> _laserWeaponFilter;
        private IStatsView _statsView;

        [IgnoreInject] private int _lastNumberOfShots;

        public void Run()
        {
            if (_laserWeaponFilter.IsEmpty == false)
            {
                ref var laserWeaponComponent = ref _laserWeaponFilter.Get1(0);
                if (_lastNumberOfShots != laserWeaponComponent.NumberOfShots)
                {
                    _lastNumberOfShots = laserWeaponComponent.NumberOfShots;
                    _statsView.UpdateLaserCount(_lastNumberOfShots.ToString(), laserWeaponComponent.MaxShots.ToString());
                }
            }
        }

        public void Init()
        {
            if (_laserWeaponFilter.IsEmpty == false)
            {
                ref var laserWeaponComponent = ref _laserWeaponFilter.Get1(0);
                _lastNumberOfShots = laserWeaponComponent.NumberOfShots;
                _statsView.SetLaserTime(laserWeaponComponent.RecoveryRate.ToString("F1"));
                _statsView.UpdateLaserCount(laserWeaponComponent.NumberOfShots.ToString(), laserWeaponComponent.MaxShots.ToString());
            }
        }
    }
}