using CustomEcs;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Events;

namespace GameLogic.Systems.Laser
{
    public class LaserShotEmitterSystem : IEcsInitSystem
    {
        private IInput _input;
        private EcsWorld _world;
        private Group<LaserWeaponComponent, ShotDelayComponent> _filter;

        public void Init()
        {
            _input.LaserAttack += () =>
            {
                if (_filter.IsEmpty == false)
                {
                    ref var laserWeaponComponent = ref _filter.Get1(0);
                    ref var shotDelayComponent = ref _filter.Get2(0);

                    if (laserWeaponComponent.NumberOfShots > 0 && shotDelayComponent.CurrentDelay <= 0)
                    {
                        laserWeaponComponent.NumberOfShots--;
                        shotDelayComponent.CurrentDelay = laserWeaponComponent.ShootDelay;
                        _world.NewEntity().Replace(new LaserShootEvent());
                    }
                }
            };
        }
    }
}