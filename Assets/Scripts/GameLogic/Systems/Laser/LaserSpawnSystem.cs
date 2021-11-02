using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Ids;
using GameLogic.Events;
using GameLogic.Factories;

namespace GameLogic.Systems.Laser
{
    public class LaserSpawnSystem : IEcsRunSystem
    {
        private Group<LaserShootEvent> _eventFilter;
        private Group<PositionComponent, RotationComponent, PlayerComponent> _playerFilter;
        private DescriptionsContainer _descriptionsContainer;
        private FactoriesContainer _factoriesContainer;

        public void Run()
        {
            if (_eventFilter.IsEmpty == false && _playerFilter.IsEmpty == false)
            {
                SpawnAsync();
                _eventFilter.GetEntity(0).Delete<LaserShootEvent>();
            }
        }


        private async void SpawnAsync()
        {
            var description = _descriptionsContainer.LaserDescriptionContainer.Get(DescriptionIds.Laser);
            var view = await _factoriesContainer.GetBaseViewFactoryFactory().CreateViewAsync<ILaserView>(description.ViewKey);

            if (_playerFilter.IsEmpty == false)
            {
                var positionComponent = _playerFilter.Get1(0);
                var rotationComponent = _playerFilter.Get2(0);
                var position = positionComponent.Position + rotationComponent.RotationDirection;

                view.Disabled += OnDisabled;
                view.Shoot(position, rotationComponent.RotationDirection, description.Duration);
            }
        }

        private void OnDisabled(ILaserView laserView)
        {
            laserView.Disabled -= OnDisabled;
            laserView.EntityLink.Replace(new DeathComponent());
        }
    }
}