using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Ids;
using GameLogic.Factories;

namespace GameLogic.Systems.Bullet
{
    public class BulletSpawnSystem : IEcsInitSystem
    {
        private IInput _input;
        private DescriptionsContainer _descriptionsContainer;
        private FactoriesContainer _factoriesContainer;
        private Group<ShotDelayComponent, BulletWeaponComponent> _shootDelayFilter;
        private Group<PositionComponent, RotationComponent, PlayerComponent> _playerGroup;

        public void Init() => _input.BulletAttack += OnBulletAttack;

        private void OnBulletAttack()
        {
            if (_shootDelayFilter.IsEmpty == false && _playerGroup.IsEmpty == false)
            {
                ref var shotDelayComponent = ref _shootDelayFilter.Get1(0);
                if (shotDelayComponent.CurrentDelay <= 0)
                {
                    SpawnAsync();
                    shotDelayComponent.CurrentDelay = shotDelayComponent.ShotDelay;
                }
            }
        }

        private async void SpawnAsync()
        {
            var bulletDescription = _descriptionsContainer.BulletDescriptionsContainer.Get(DescriptionIds.BulletDefault);
            var bulletFactory = _factoriesContainer.GetBulletFactory();

            await bulletFactory.CreateViewAsync<IMovableView>(bulletDescription.ViewKey);

            if (_playerGroup.IsEmpty == false)
            {
                var playerPositionComponent = _playerGroup.Get1(0);
                var playerRotationComponent = _playerGroup.Get2(0);

                var newPosition = playerPositionComponent.Position + playerRotationComponent.RotationDirection * 1.4f;
                bulletFactory.CreateEntity(newPosition,
                    playerRotationComponent.RotationDirection,
                    playerRotationComponent.RotationDirection,
                    bulletDescription.InstantVelocity,
                    bulletDescription.Score,
                    bulletDescription.LifeTime);
            }
        }
    }
}