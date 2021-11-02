using System.Numerics;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Ids;
using GameLogic.Events;
using GameLogic.Factories;

namespace GameLogic.Systems.Meteor
{
    public class MeteorSpawnSystem : IEcsRunSystem
    {
        private Group<PositionComponent, MotionDirectionComponent, VelocityComponent, MeteorSpawnEvent> _filter;
        private IRandom _random;
        private DescriptionsContainer _descriptionsContainer;
        private FactoriesContainer _factoriesContainer;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var parentPositionComponent = ref _filter.Get1(i);
                ref var parentDirectionComponent = ref _filter.Get2(i);
                ref var parentVelocityComponent = ref _filter.Get3(i);

                var instantVelocity = parentVelocityComponent.InstantVelocity * 2;
                for (int j = 0; j < 3; j++)
                {
                    var direction = Vector2.Normalize(parentDirectionComponent.Direction + new Vector2(_random.Range(-1, 1), _random.Range(-1, 1)));
                    SpawnAsync(parentPositionComponent.Position, instantVelocity, direction);
                    _filter.GetEntity(i).Delete<MeteorSpawnEvent>();
                }
            }
        }

        private async void SpawnAsync(Vector2 parentPosition, Vector2 instantVelocity, Vector2 direction)
        {
            var description = _descriptionsContainer.ScoreDescriptionsContainer.Get(DescriptionIds.MeteorDefault);
            var meteorFactory = _factoriesContainer.GetMeteorFactory();
            await meteorFactory.CreateViewAsync<IMovableView>(description.ViewKey);
            meteorFactory.CreateEntity(parentPosition, instantVelocity, direction, description.Score, description.Size);
        }
    }
}