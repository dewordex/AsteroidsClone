using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Ids;
using GameLogic.Descriptions.Variants;

namespace GameLogic.Descriptions.Containers
{
    public class BulletDescriptionContainer : DescriptionsContainer<BulletDescription>
    {
        public BulletDescriptionContainer()
        {
            Add(DescriptionIds.BulletDefault, new BulletDescription(ViewIds.Bullet, 0.25f,0.9f,10, 15, 3));
        }
    }
}