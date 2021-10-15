﻿using System.Collections.Generic;
using System.Numerics;
using GameLogic.Descriptions.Base;
using GameLogic.Descriptions.Entity;
using GameLogic.Descriptions.Ids;

namespace GameLogic.Descriptions
{
    public class EntitiesDescriptionsGenerator
    {
        public readonly IReadOnlyDictionary<string, IDescription> ComponentsContainers = new Dictionary<string, IDescription>()
        {
            { DescriptionIds.AsteroidDefault, new MovableEntityDescription("asteroid", new Vector2(2, 0)) },
            { DescriptionIds.AsteroidFast, new MovableEntityDescription("asteroid", new Vector2(5, 0)) },
            { DescriptionIds.SpaceshipDefault, new SpaceshipDescription("spaceship", 15, 2) },
            { DescriptionIds.UfoDefault, new MovableEntityDescription("ufo", new Vector2(5, 0)) },
        };
    }
}