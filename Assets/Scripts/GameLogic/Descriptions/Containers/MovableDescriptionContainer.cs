using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Ids;
using GameLogic.Descriptions.Variants;

namespace GameLogic.Descriptions.Containers
{
    public class MovableDescriptionContainer : DescriptionsContainer<MovableDescription>
    {
        public MovableDescriptionContainer()
        {
            Add(DescriptionIds.AsteroidFast, new MovableDescription(ViewIds.Asteroid, 2, 2, 200, 5));
            Add(DescriptionIds.AsteroidDefault, new MovableDescription(ViewIds.Asteroid, 2, 2, 200, 2));
            Add(DescriptionIds.UfoDefault, new MovableDescription(ViewIds.Ufo, 1, 1, 200, 5));
        }
    }
}