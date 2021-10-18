﻿using GameLogic.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Components;
using GameLogic.Descriptions.Entity;
using GameLogic.Descriptions.Ids;
using GameLogic.Events;
using Leopotam.Ecs;

namespace GameLogic.Systems.Laser
{
    public class LaserSpawnSystem : IEcsRunSystem
    {
        private EcsFilter<LaserShootEvent> _eventFilter;
        private EcsFilter<Component<ITransform>, PlayerComponent> _playerFilter;
        private IEntityFactory _entityFactory;

        public void Run()
        {
            if (_eventFilter.IsEmpty() == false)
            {
                var laserComponentContainer = new EmptyComponentContainer<ILaserView, LaserDescription>();
                _entityFactory.StartCreate(laserComponentContainer, DescriptionIds.LaserDefault).Completed += handle =>
                {
                    if (_playerFilter.IsEmpty() == false)
                    {
                        ref var transform = ref _playerFilter.Get1(0).Value;
                        laserComponentContainer.View.Disabled += OnDisabled;
                        laserComponentContainer.View.Shoot(transform.Position + transform.Up * transform.Scale, transform.Up, laserComponentContainer.Description.Duration);
                    }
                };
                
                _eventFilter.GetEntity(0).Del<LaserShootEvent>();
            }
        }

        private void OnDisabled(ILaserView laserView)
        {
            laserView.Disabled -= OnDisabled;
            laserView.EntityLink.Replace(new DeathComponent());
        }
    }
}