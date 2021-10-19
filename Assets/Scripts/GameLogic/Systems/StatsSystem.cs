using System.Text;
using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class StatsSystem : IEcsRunSystem
    {
        private IStatsView _statsView;
        private EcsFilter<VelocityComponent, Component<ITransform>, StatsComponent> _playerFilter;
        private EcsFilter<LaserWeaponComponent> _laserWeaponFilter;

        public void Run()
        {
            if (_playerFilter.IsEmpty() == false && _laserWeaponFilter.IsEmpty() == false)
            {   
                var stringBuilder = new StringBuilder();
                ref var velocityComponent = ref _playerFilter.Get1(0);
                ref var transform = ref _playerFilter.Get2(0).Value;
                ref var laserWeaponComponent = ref _laserWeaponFilter.Get1(0);

                stringBuilder.AppendLine($"Позиция: ({transform.Position.X:F0}, {transform.Position.Y:F0})");
                stringBuilder.AppendLine($"Угол поворота: {transform.GetRotateAngle():F0}");
                stringBuilder.AppendLine($"Мгновенная скорость: {velocityComponent.InstantVelocity.Length():F0}");
                stringBuilder.AppendLine($"Число зарядов лазера: {laserWeaponComponent.NumberOfShots}/{laserWeaponComponent.MaxShots}");
                stringBuilder.AppendLine($"Время восстановления лазера: {laserWeaponComponent.RecoveryRate} с");
                _statsView.SetStats(stringBuilder.ToString());
            }
        }
    }
}