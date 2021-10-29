using System.Numerics;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.Base;
using GameLogic.Dependencies.View.Components;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Components;
using GameLogic.Descriptions.Ids;
using GameLogic.Events;

namespace GameLogic.Systems.Meteor
{
    public class MeteorSpawnSystem : IEcsRunSystem
    {
        private Group<Component<ITransform>, MotionDirectionComponent, VelocityComponent, MeteorSpawnEvent> _filter;
        private IEntityFactory _entityFactory;
        private IRandom _random;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var parentPosition = _filter.Get1(i).Value.Position;
                var parentDirection = _filter.Get2(i).Direction;
                var parentVelocity = _filter.Get3(i).InstantVelocity;

                for (int j = 0; j < 3; j++)
                {
                    
                    SpawnMeteor(parentPosition, Vector2.Normalize(parentDirection + new Vector2(_random.Range(-1,1), _random.Range(-1,1))), parentVelocity);
                }


                _filter.GetEntity(i).Delete<MeteorSpawnEvent>();
            }
        }

        private void SpawnMeteor(Vector2 parentPosition, Vector2 parentDirection, Vector2 parentVelocity)
        {
            var meteorComponentsContainer = new MeteorComponentsContainer();
            _entityFactory.StartCreate(meteorComponentsContainer, DescriptionIds.MeteorDefault).Completed += handle =>
            {
                meteorComponentsContainer.View.Transform.Position = parentPosition;
                meteorComponentsContainer.EcsEntity.Get<MotionDirectionComponent>().Direction = parentDirection;
                meteorComponentsContainer.EcsEntity.Get<VelocityComponent>().InstantVelocity = parentVelocity * meteorComponentsContainer.Description.MultiplierSpeed;
            };
        }
    }
}