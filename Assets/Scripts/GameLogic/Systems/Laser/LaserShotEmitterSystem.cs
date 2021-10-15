using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Events;
using Leopotam.Ecs;

namespace GameLogic.Systems.Laser
{
    public class LaserShotEmitterSystem : IEcsInitSystem
    {
        private IInput _input;
        private EcsWorld _world;
        private EcsFilter<LaserWeaponComponent, ShotDelayComponent> _filter;

        public void Init()
        {
            _input.LaserAttack += () =>
            {
                if (_filter.IsEmpty() == false)
                {
                    ref var laserWeaponComponent = ref _filter.Get1(0);
                    ref var shotDelayComponent = ref _filter.Get2(0);

                    if (laserWeaponComponent.NumberOfShots > 0 && shotDelayComponent.Delay <= 0)
                    {
                        laserWeaponComponent.NumberOfShots--;
                        shotDelayComponent.Delay = laserWeaponComponent.ShootDelay;
                        _world.NewEntity().Replace(new LaserShootEvent());
                    }
                }
            };
        }
    }
}