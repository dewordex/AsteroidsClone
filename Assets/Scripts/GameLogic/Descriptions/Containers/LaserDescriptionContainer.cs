using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Ids;
using GameLogic.Descriptions.Variants;

namespace GameLogic.Descriptions.Containers
{
    public class LaserDescriptionContainer : DescriptionsContainer<LaserDescription>
    {
        public LaserDescriptionContainer()
        {
            Add(DescriptionIds.Laser,  new LaserDescription(ViewIds.Laser,1,1, 1));
        }
    }
}