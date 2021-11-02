using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Ids;
using GameLogic.Descriptions.Variants;

namespace GameLogic.Descriptions.Containers
{
    public class ScoreDescriptionContainer : DescriptionsContainer<ScoreDescription>
    {
        public ScoreDescriptionContainer()
        {
            Add(DescriptionIds.MeteorDefault, new ScoreDescription(ViewIds.Meteor, 200));
        }
    }
}