using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Ids;
using GameLogic.Descriptions.Variants;

namespace GameLogic.Descriptions.Containers
{
    public class SpaceshipDescriptionContainer : DescriptionsContainer<SpaceshipDescription>
    {
        public SpaceshipDescriptionContainer()
        {
            Add(DescriptionIds.SpaceshipDefault, new SpaceshipDescription(ViewIds.Spaceship, 1, 1, 15, 1.5f));
        }
    }
}