using CustomEcs.Systems;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Components;
using GameLogic.Descriptions.Ids;

namespace GameLogic.Systems.Spaceship
{
    public class SpaceshipSpawnSystem : IEcsInitSystem
    {
        private IEntityFactory _factory;
        public void Init() => _factory.StartCreate(new SpaceshipComponentsContainer(), DescriptionIds.SpaceshipDefault);
    }
}