using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Ids;
using GameLogic.Descriptions.Variants;

namespace GameLogic.Descriptions.Containers
{
    public class AsteroidSpawnDescriptionContainer : DescriptionsContainer<AsteroidSpawnDescription>
    {
        public AsteroidSpawnDescriptionContainer()
        {
            Add(DescriptionIds.AsteroidSpawnSettings, new AsteroidSpawnDescription(40, 600, 4));
        }
    }
}