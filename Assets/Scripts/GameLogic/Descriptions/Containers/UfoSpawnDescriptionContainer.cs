using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Ids;
using GameLogic.Descriptions.Variants;

namespace GameLogic.Descriptions.Containers
{
    public class UfoSpawnDescriptionContainer : DescriptionsContainer<UfoSpawnDescription>
    {
        public UfoSpawnDescriptionContainer()
        {
            Add(DescriptionIds.UfoSpawnSettings, new UfoSpawnDescription(5, 20));
        }
    }
}