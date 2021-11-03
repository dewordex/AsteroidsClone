using CustomEcs.Systems;
using GameLogic.Dependencies.View;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Ids;
using GameLogic.Factories;

namespace GameLogic.Systems.Spaceship
{
    public class SpaceshipSpawnSystem : IEcsInitSystem
    {
        private FactoriesContainer _factoriesContainer;
        private DescriptionsContainer _descriptions;

        public void Init() => SpawnAsync();

        private async void SpawnAsync()
        {
            var spaceshipFactory = _factoriesContainer.GetSpaceshipFactory();
            var spaceshipDescription = _descriptions.SpaceshipDescriptionsContainer.Get(DescriptionIds.SpaceshipDefault);
            await spaceshipFactory.CreateViewAsync<IMovableView>(spaceshipDescription.ViewKey);
            spaceshipFactory.CreateEntity(spaceshipDescription.Acceleration, spaceshipDescription.Mass, spaceshipDescription.Size);
        }
    }
}